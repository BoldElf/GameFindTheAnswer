using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using DG.Tweening;
using UnityEngine.UI;

public class RestartPanelSystem : MonoBehaviour
{
    [Inject] private LevelManager levelManager;
    [SerializeField] private float FadeValue;
    [SerializeField] private float FadeDuration;

    [SerializeField] private GameObject blackPanelPrefab;
    [SerializeField] private GameObject LoadPanel;
    [SerializeField] private Transform parentObject;

    private GameObject defaultPanelObject;
    private Image imagePanel;

    private bool blackPanelActive;

    private float time = 100;

    private void Start()
    {
        levelManager.LevelStartEvent += LevelStartPanel;
        levelManager.LevelEndEvent += LevelEndPanel;
    }

    IEnumerator FadeIn(GameObject panel, float number)
    {
        //float i = 0;

        defaultPanelObject = Instantiate(panel, parentObject);

        imagePanel = defaultPanelObject.GetComponent<Image>();

        Color color = imagePanel.color;

        while (imagePanel.color.a < number)
        {
            color.a += 10f * Time.deltaTime;
            imagePanel.color = color;
            yield return new WaitForSeconds(10f * Time.deltaTime);
        }

        blackPanelActive = true;
    }

    
    /*
    IEnumerator FadeOut()
    {



    }
    */

    private void LevelStartPanel()
    {
        if(blackPanelActive == true)
        {
            StartCoroutine(FadeIn(LoadPanel, 1f));
            blackPanelActive = false;
        }
        
    }

    private void LevelEndPanel()
    {
        StartCoroutine(FadeIn(blackPanelPrefab, 0.8f));
    }


    /*
    private void LevelEndPanel()
    {
        blackPanelObject = Instantiate(blackPanelPrefab,parentObject);

        if(blackPanelObject.TryGetComponent<Image>(out imagePanel))
        {
            imagePanel.DOFade(FadeValue, FadeDuration).SetLink(blackPanelObject);
        }
    }

    private void LevelStartPanel()
    {
        
    }
    */
}
