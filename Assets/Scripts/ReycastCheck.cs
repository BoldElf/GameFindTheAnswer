using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

public class ReycastCheck : MonoBehaviour
{
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");
    }
    */

    //RaycastHit2D hit = new RaycastHit2D();

    [Inject] private SetFindSystem setFindSystem;

    private ButtonController button;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Destroy(hit.collider.gameObject);

                if(hit.collider.TryGetComponent<ButtonController>(out button))
                {
                    setFindSystem.CheckEndNumber(button);
                }
            }
        }
    }
}

