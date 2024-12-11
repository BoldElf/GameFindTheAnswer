using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New CardData", menuName = "CardData", order = 52)]
public class CardData : ScriptableObject
{
    [SerializeField] private string identifier;

    [SerializeField] private Sprite image;

    [SerializeField] private bool flip;

    public Sprite getImage()
    {
        return image;
    }

    public string getIdentifier()
    {
        return identifier;
    }

    public bool getFlip()
    {
        return flip;
    }
}
