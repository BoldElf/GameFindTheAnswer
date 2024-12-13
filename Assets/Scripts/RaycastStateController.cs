using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Game
{
    public class RaycastStateController : MonoBehaviour
    {
        [Inject] private LevelManager levelManager;
        [Inject] private RaycastCheck reycastCheck;

        void Start()
        {
            levelManager.LevelStartEvent += LevelStart;
            levelManager.LevelEndEvent += LevelEnd;
        }

        private void LevelStart()
        {
            reycastCheck.gameObject.SetActive(true);
        }

        private void LevelEnd()
        {
            reycastCheck.gameObject.SetActive(false);
        }
    }

}
