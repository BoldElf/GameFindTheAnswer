using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "level", order = 51)]
public class Level : ScriptableObject
{
    [SerializeField]private int elements;

    public int getCountElements()
    {
        return elements;
    }
}
