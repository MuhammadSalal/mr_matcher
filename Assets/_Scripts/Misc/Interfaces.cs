using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    public interface ICard
    {

        public void SetCard(CardData cardData);

        public void FlipShow();
        public void FlipNoMatch();

        public int GetID();
    }
}
