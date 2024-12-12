using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SetFindSystem : MonoBehaviour
{
    [SerializeField] private List<CardBudle> cardBundl = new List<CardBudle>();

    [SerializeField] private int currentOption;
    [SerializeField] private int currentElement;

    private List<int> currentNumber = new List<int>();

    private int endNumber;
    private int EnterCount;

    public delegate void FindSystem();
    public event FindSystem Notify;

    public delegate void WrongSystem(GameObject button);
    public event WrongSystem WrongChoice;

    public delegate void Win (ButtonController button);
    public event Win spawnParticle;

    private List<int> endCard = new List<int>();
    private CardData EndButton;

    private bool OneEndButton;

    private void Awake()
    {
        currentOption = Random.Range(0, cardBundl.Count);
        /*
        currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
        endNumber = currentElement + 1;
        */
        CreateEndNumber();
        setEndNumberButton();
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
        EnterCount++;

        currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());

        for (int i = 0; i < currentNumber.Count; i++)
        {
            if ( (endNumber) != currentNumber[i])
            {
                currentElement = Random.Range(0, 3);

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
                if( (endNumber) != currentNumber[i])
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

        if(OneEndButton == true)
        {
            while(currentElement == endNumber)
            {
                currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
            }
            
        }

        if(currentElement == endNumber)
        {
            OneEndButton = true;
        }
        

        currentNumber.Add(currentElement);

        //return cardBundl[currentOption].getCardData(currentElement).getImage();
        return cardBundl[currentOption].getCardData(currentElement);
    }


    public  void CheckEndNumber(ButtonController button)
    {
        /*
        if(endNumber == button.GetIndefire())
        {
            Notify?.Invoke();
        }
        else
        {
            Debug.Log("No");
        }
        */

        if(EndButton.getIdentifier() == button.GetIndefire())
        {
            spawnParticle?.Invoke(button);

            //Notify?.Invoke();
        }
        else
        {
            WrongChoice?.Invoke(button.gameObject);
        }


    }

    public void GlobalClearData()
    {
        currentOption = Random.Range(0, cardBundl.Count);
        ClearDataNextLevel();
        endCard.Clear();
    }

    public void ClearDataNextLevel()
    {
        endCard.Add(endNumber);
        OneEndButton = false;
        /*
        currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
        endNumber = currentElement + 1;
        */
        CreateEndNumber();

        for (int i = 0; i < endCard.Count;i++)
        {
            if(endCard[i] == endNumber)
            {
                i = 0;
                /*
                currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
                endNumber = currentElement + 1;
                */
                CreateEndNumber();
            }
        }
        setEndNumberButton();
        EnterCount = 0;
        currentNumber.Clear();
    }
    private void CreateEndNumber()
    {
        currentElement = Random.Range(0, cardBundl[currentOption].getCountCard());
        endNumber = currentElement;
    }

    private void setEndNumberButton()
    {
        EndButton = cardBundl[currentOption].getCardData(endNumber);
        Debug.Log(EndButton.getIdentifier());
    }

    public string getEndNumberButton()
    {
        if(EndButton != null)
        {
            return EndButton.getIdentifier();
        }
        else
        {
            return "erorr";
        }
    }

    public void NextLevel()
    {
        Notify?.Invoke();
    }
}
