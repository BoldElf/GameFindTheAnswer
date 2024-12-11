using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFindSystem : MonoBehaviour
{
    [SerializeField] private List<CardBudle> cardBundl = new List<CardBudle>();

    [SerializeField] private int maxOptions =  1;
    [SerializeField] private int maxElements = 8;

    [SerializeField] private int currentOption;
    [SerializeField] private int currentElement;

    private List<int> currentNumber = new List<int>();

    private int endNumber;
    private int EnterCount;

    private void Awake()
    {
        currentOption = Random.Range(0, cardBundl.Count);
        currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
        endNumber = currentElement;
    }

    public int GetCurrentOption()
    {
        return currentOption; 
    }

    public int GetCurrentElement()
    {
        return currentElement;
    }

    public CardData reRollElement(int countElements)
    {
        Debug.Log(endNumber);
        EnterCount++;


        currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());

        for (int i = 0; i < currentNumber.Count; i++)
        {
            if (endNumber != currentNumber[i])
            {
                currentElement = Random.Range(0, 2);

                if(currentElement == 0)
                {
                    currentElement = endNumber;
                }
            }
        }

        int check = 0;

        if(countElements == EnterCount)
        {
            for(int i = 0; i < currentNumber.Count;i++)
            {
                if(endNumber != currentNumber[i])
                {
                    check++;
                }   
            }

            if(check == countElements-1)
            {
                currentElement = endNumber;
            }
        }

        for (int i = 0; i < currentNumber.Count; i++)
        {
            if (currentElement == currentNumber[i])
            {
                currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
                i = 0;
            }
        }

        currentNumber.Add(currentElement);

        //return cardBundl[currentOption].getCardData(currentElement).getImage();
        return cardBundl[currentOption].getCardData(currentElement);
    }

}
