using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    [SerializeField] private Text  text;
    [SerializeField] private GameObject restart;

    public delegate void UiRestrtart();
    public event UiRestrtart GoRestrart;

    public void setText(string textNumber)
    {
        text.text = textNumber;
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
