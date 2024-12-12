using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class RaycastStateController : MonoBehaviour
{
    [Inject] private LevelManager levelManager;
    [Inject] private RaycastCheck reycastCheck;

    // Start is called before the first frame update
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
        Debug.Log("LevelEnd");
    }
}
