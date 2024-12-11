using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Level> levels = new List<Level>();
    [Inject] private Rendering rendering;

    [SerializeField] private int currentLevel = 0; // DBG

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        if(currentLevel < levels.Count)
        {
            if(rendering != null)
            {
                rendering.renderGrid(levels[currentLevel].getCountElements());
            }
            else
            {
                Debug.Log("Error rendering depend");
            }
        }
    }
}
