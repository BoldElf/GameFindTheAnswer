using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using DG.Tweening;
using UnityEngine.UI;

namespace Game
{
    public class RestartPanelSystem : MonoBehaviour
    {
        [Inject] private LevelManager levelManager;

        [SerializeField] private GameObject blackPanelPrefab;
        [SerializeField] private GameObject LoadPanel;
        [SerializeField] private Transform parentObject;

        [SerializeField] private UIText uiText;

        private GameObject defaultPanelObject;
        private Image imagePanel;

        private float alfaBlackColor = 0.8f;
        private float alfaLoadColor = 1f;

        private void Start()
        {
            levelManager.LevelEndEvent += LevelEndPanel;
            uiText.GoLoadPanel += startLoadPanel;
            uiText.GoClosePanel += startGoClosePanel;
        }

        private void startGoClosePanel()
        {
            StartCoroutine(FadeOutLoad());
        }

        private void startLoadPanel()
        {
            StartCoroutine(FadeInLoad(LoadPanel, alfaLoadColor));
        } 

        private void LevelEndPanel()
        {
            StartCoroutine(FadeInBlack(blackPanelPrefab, alfaBlackColor));
        }

        IEnumerator FadeInBlack(GameObject panel, float number)
        {
            defaultPanelObject = Instantiate(panel, parentObject);

            imagePanel = defaultPanelObject.GetComponent<Image>();

            Color color = imagePanel.color;

            while (imagePanel.color.a < number)
            {
                color.a += 20f * Time.deltaTime;
                imagePanel.color = color;
                yield return new WaitForSeconds(10f * Time.deltaTime);
            }
        }

        IEnumerator FadeInLoad(GameObject panel, float number)
        {
            Destroy(defaultPanelObject);

            defaultPanelObject = Instantiate(panel, parentObject);

            imagePanel = defaultPanelObject.GetComponent<Image>();

            Color color = imagePanel.color;

            while (imagePanel.color.a < number)
            {
                color.a += 20f * Time.deltaTime;
                imagePanel.color = color;
                yield return new WaitForSeconds(10f * Time.deltaTime);
            }
        }

        IEnumerator FadeOutLoad()
        {
            imagePanel = defaultPanelObject.GetComponent<Image>();

            Color color = imagePanel.color;

            while (imagePanel.color.a > 0f)
            {
                color.a -= 5f * Time.deltaTime;
                imagePanel.color = color;
                yield return new WaitForSeconds(5f * Time.deltaTime);
            }
            Destroy(defaultPanelObject);
        }
    }
}

