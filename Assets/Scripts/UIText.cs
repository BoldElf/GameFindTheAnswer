using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game
{
    public class UIText : MonoBehaviour
    {
        [SerializeField] private Transform parentPlace;
        [SerializeField] private GameObject prefabText;
        [SerializeField] private Text  text;
        [SerializeField] private GameObject restart;

        public delegate void UiRestrtart();
        public event UiRestrtart GoRestrart;

        public event UiRestrtart GoLoadPanel;
        public event UiRestrtart GoClosePanel;

        public float FadeValue;
        public float FadeDuration;

        private GameObject currentText;

        private Tween tween;

        private bool startTimer;
        private float timer;
        private bool loadPanel = false;

        public void setText(string textNumber)
        {
            if(currentText != null)
            {
                tween.Kill();
                Destroy(currentText);
            }

            currentText = Instantiate(prefabText, parentPlace.transform);

            if(currentText.TryGetComponent<Text>(out text))
            {
                text.text = textNumber;
                tween = text.DOFade(FadeValue, FadeDuration).SetLink(currentText);
            }
        }

        public void setRestart()
        {
            restart.SetActive(true);
        }
    
        public void startRestart()
        {
            startTimer = true;
            loadPanel = true;
        }

        private void Update()
        {
            LoadPanelSettings();
        }

        private void LoadPanelSettings()
        {
            if (startTimer == true)
            {
                if (loadPanel == true)
                {
                    GoLoadPanel?.Invoke();
                    loadPanel = false;
                }

                timer += Time.deltaTime;

                if (timer > 1)
                {
                    GoClosePanel?.Invoke();
                    GoRestrart?.Invoke();
                    startTimer = false;
                    timer = 0;
                }
            }
        }
    }

}
