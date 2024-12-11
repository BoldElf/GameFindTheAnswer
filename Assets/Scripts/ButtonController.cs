using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Image mainSprite;
    
    public void setSprite(Sprite sprite)
    {
        mainSprite.sprite = sprite;
    }
}
