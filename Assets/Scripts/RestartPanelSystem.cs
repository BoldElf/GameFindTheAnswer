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
        [SerializeField] private float FadeValue;
        [SerializeField] private float FadeDuration;

        [SerializeField] private GameObject blackPanelPrefab;
        [SerializeField] private GameObject LoadPanel;
        [SerializeField] private Transform parentObject;

        [SerializeField] private UIText uiText;

        private GameObject defaultPanelObject;
        private Image imagePanel;

        private void Start()
        {
            levelManager.LevelEndEvent += LevelEndPanel;
        }

        IEnumerator FadeIn(GameObject panel, float number)
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

        private void LevelEndPanel()
        {
            StartCoroutine(FadeIn(blackPanelPrefab, 0.8f));
        }

        public void ClearPanel()
        {
            StartCoroutine(FadeOut());
        }

        public void RestartPanel()
        {
            StartCoroutine(FadeIn(LoadPanel,1f));
        }

        IEnumerator FadeOut()
        {
            imagePanel = defaultPanelObject.GetComponent<Image>();

            Color color = imagePanel.color;

            while (imagePanel.color.a > 0f)
            {
                color.a -= 10f * Time.deltaTime;
                imagePanel.color = color;
                yield return new WaitForSeconds(10f * Time.deltaTime);
            }
        }

    }
}

