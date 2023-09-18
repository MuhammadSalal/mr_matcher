using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    [System.Serializable]
    public struct CardData
    {
        public int ID;
        public Sprite Sprite;

        public CardData(int id, Sprite sprite)
        {
            ID = id;
            Sprite = sprite;
        }
    }
}
