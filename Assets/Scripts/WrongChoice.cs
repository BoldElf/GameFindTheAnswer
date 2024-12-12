using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using DG.Tweening;

public class WrongChoice : MonoBehaviour
{
    [Inject] SetFindSystem setFindSystem;
    MovePictureScripts movePictureScripts;


    void Start()
    {
        setFindSystem.WrongChoice += SetFindSystem_WrongChoice;
    }

    private void SetFindSystem_WrongChoice(GameObject button)
    {
        Debug.Log("Try");
        if (button.TryGetComponent<MovePictureScripts>(out movePictureScripts))
        {
            movePictureScripts.ButtonEffect();
        }
        //button.transform.DOMove(endValue: new Vector3(x: button.transform.position.x + 0.5f, y: 0.5f, z: 0.5f), duration: 2);
    }
}
