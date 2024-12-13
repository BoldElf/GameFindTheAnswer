using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using DG.Tweening;

namespace Game
{
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
            if (button.TryGetComponent<MovePictureScripts>(out movePictureScripts))
            {
                movePictureScripts.ButtonEffect();
            }
        }
    }
}

