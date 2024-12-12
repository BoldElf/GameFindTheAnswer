using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Image mainSprite;
    private string indefire;
    
    public void SetSprite(Sprite sprite)
    {
        mainSprite.sprite = sprite;
    }

    public void SetIndefire(string number)
    {
        indefire = number;
    }

    public string GetIndefire()
    {
        return indefire;
    }

    public Image getSprite()
    {
        return mainSprite;
    }
}
