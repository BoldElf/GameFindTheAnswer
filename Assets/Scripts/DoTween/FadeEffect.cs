using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
	public Text TestImage;

	public float FadeValue;
	public float FadeDuration;

    private void Start()
    {
        //TestImage.DOFade(FadeValue, FadeDuration);
    }
}
