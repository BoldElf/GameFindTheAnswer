using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Game
{
    public class RaycastCheck : MonoBehaviour
    {
        [Inject] private SetFindSystem setFindSystem;

        private ButtonController button;

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if(hit.collider.TryGetComponent<ButtonController>(out button))
                    {
                        setFindSystem.CheckEndNumber(button);
                    }
                }
            }
        }
    }
}


