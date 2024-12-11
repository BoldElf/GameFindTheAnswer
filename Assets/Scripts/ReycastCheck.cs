using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReycastCheck : MonoBehaviour
{
    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");
    }
    */

    RaycastHit2D hit = new RaycastHit2D();


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            //Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

