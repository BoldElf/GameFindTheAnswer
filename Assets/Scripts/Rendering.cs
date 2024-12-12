using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class Rendering : MonoBehaviour
{
    [SerializeField] private GameObject prefabButton;
    [SerializeField] private Transform parentTransform;

    //[Inject] SetFindSystem setFindSystem;

    private GameObject currentButton;
    private ButtonController currentButtonController;
    private CardData cardData;

    public delegate void CreateObject(GameObject gameObject);
    public event CreateObject ObjectIsHere;

    /*
    public void renderGrid(int countElements)
    {
        for(int i = 0; i < countElements;i++)
        {
            currentButton = Instantiate(prefabButton, parentTransform);

            if(currentButton.TryGetComponent<ButtonController>(out currentButtonController))
            {
                cardData = setFindSystem.reRollElement(countElements);

                //currentButtonController.setSprite(setFindSystem.reRollElement().getImage());
                currentButtonController.SetSprite(cardData.getImage());
                currentButtonController.SetIndefire(cardData.getIdentifier());

                if (cardData.getFlip() == true)
                {
                    currentButtonController.transform.Rotate(0, 0, -90);
                }
            }
        }
    */

    public void renderGrid(int countElements, SetFindSystem setFindSystem)
    {
        for (int i = 0; i < countElements; i++)
        {
            currentButton = Instantiate(prefabButton, parentTransform);

            if (currentButton.TryGetComponent<ButtonController>(out currentButtonController))
            {
                cardData = setFindSystem.reRollElement(countElements);

                //currentButtonController.setSprite(setFindSystem.reRollElement().getImage());
                currentButtonController.SetSprite(cardData.getImage());
                currentButtonController.SetIndefire(cardData.getIdentifier());

                if (cardData.getFlip() == true)
                {
                    //currentButtonController.transform.Rotate(0, 0, -90);
                    // currentButtonController.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));

                    currentButtonController.getSprite().transform.Rotate(0, 0, -90);
                }
            }

            ObjectIsHere?.Invoke(currentButton);
        }
    }

    public void ClearRender(SetFindSystem setFindSystem)
    {
        while (parentTransform.childCount > 0)
        {
            DestroyImmediate(parentTransform.GetChild(0).gameObject);
        }

        setFindSystem.ClearDataNextLevel();
    }
}
