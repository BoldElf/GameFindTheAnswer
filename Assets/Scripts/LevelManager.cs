using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class LevelManager : MonoBehaviour
{
    [Inject] private UIText uIText;
    [Inject] private Rendering rendering;
    [Inject] private SetFindSystem setFindSystem;

    [SerializeField] private List<Level> levels = new List<Level>();
    [SerializeField] private int currentLevel = 0; // DBG

    public delegate void LevelManagerDelegate();
    public event LevelManagerDelegate LevelStartEvent;

    public event LevelManagerDelegate LevelEndEvent;

    private void Start()
    {
        StartLevel();
        setFindSystem.Notify += NextLevel;
        uIText.GoRestrart += Restart;
    }

    private void NextLevel()
    {
        if(currentLevel < levels.Count - 1)
        {
            rendering.ClearRender(setFindSystem);
            currentLevel++;
            StartLevel();
        }
        else
        {
            LevelEndEvent?.Invoke();
            uIText.setRestart();
        }

    }

    private void Restart()
    {
        setFindSystem.GlobalClearData();
        currentLevel = 0;
        rendering.ClearRender(setFindSystem);
        StartLevel();
        Debug.Log("Restart");
    }

    private void StartLevel()
    {
        if (currentLevel < levels.Count)
        {
            if (rendering != null)
            {
                LevelStartEvent?.Invoke();
                rendering.renderGrid(levels[currentLevel].getCountElements(), setFindSystem);
                uIText.setText("Find: " + " " + setFindSystem.getEndNumberButton());
            }
            else
            {
                Debug.Log("Error rendering depend");
            }
        }
    }
}
