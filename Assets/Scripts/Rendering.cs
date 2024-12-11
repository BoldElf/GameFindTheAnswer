using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class Rendering : MonoBehaviour
{
    [SerializeField] private GameObject prefabButton;
    [SerializeField] private Transform parentTransform;
    [Inject] SetFindSystem setFindSystem;

    private GameObject currentButton;
    private ButtonController currentButtonController;
    private CardData cardData;
    public void renderGrid(int countElements)
    {
        for(int i = 0; i < countElements;i++)
        {
            currentButton = Instantiate(prefabButton, parentTransform);

            if(currentButton.TryGetComponent<ButtonController>(out currentButtonController))
            {
                cardData = setFindSystem.reRollElement(countElements);

                //currentButtonController.setSprite(setFindSystem.reRollElement().getImage());
                currentButtonController.setSprite(cardData.getImage());

                if(cardData.getFlip() == true)
                {
                    currentButtonController.transform.Rotate(0, 0, -90);
                }
            }
                
            
        }
    }
}
