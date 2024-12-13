using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New CardBudle", menuName = "CardBudle", order = 53)]
    public class CardBudle : ScriptableObject
    {
        [SerializeField] private List<CardData> cardData = new List<CardData>();

        public CardData getCardData(int number)
        {
            return cardData[number];
        }

        public int getCountCard()
        {
            return cardData.Count;
        }
    }
}

