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

        public float FadeValue;
        public float FadeDuration;

        private GameObject currentText;

        private Tween tween;

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
            GoRestrart?.Invoke();
        }
    }

}
