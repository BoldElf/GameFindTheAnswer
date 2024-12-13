using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game
{
    public class BounceEffect : MonoBehaviour
    {
        [Inject] Rendering rendering;
        [Inject] UIText text;

        [SerializeField] private float FadeValue;
        [SerializeField] private float FadeDuration;

        private Vector3 scale;

        void Start()
        {
            rendering.ObjectIsHere += StartBounceEffect;
        }

        private void StartBounceEffect(GameObject buttonObject)
        {
            scale = buttonObject.transform.localScale;

            DOTween.Sequence().
            Append(buttonObject.transform.DOScale(endValue: 2.8f, duration: 0.5f)).
            AppendInterval(0.1f).
            Append(buttonObject.transform.DOScale(endValue: 2, duration: 0.5f)).
            AppendInterval(0.1f).
            Append(buttonObject.transform.DOScale(endValue: scale, duration: 0.5f)).
            SetLink(buttonObject);
        }
    }
}

