using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MovePictureScripts : MonoBehaviour
    {
        [SerializeField] private GameObject imageObject;
        [SerializeField] private GameObject position1;
        [SerializeField] private Transform position2;

        private Transform startPosition;

        private void Start()
        {
            startPosition = gameObject.transform;
        }

        public void ButtonEffect()
        {
            DOTween.Sequence().
            Append(imageObject.transform.DOMove(endValue: new Vector3(position1.transform.position.x, transform.position.y, position1.transform.position.z), duration: 0.3f)).SetEase(Ease.InBounce).
            Append(imageObject.transform.DOMove(endValue: new Vector3(position2.transform.position.x, transform.position.y, position2.transform.position.z), duration: 0.3f)).SetEase(Ease.InBounce).
            Append(imageObject.transform.DOMove(endValue: new Vector3(startPosition.position.x, startPosition.position.y, startPosition.transform.position.z), duration: 0.3f)).SetEase(Ease.InBounce).
            SetLink(imageObject).SetEase(Ease.InBounce);
        }
    }
}

