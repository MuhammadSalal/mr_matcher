using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    public static class EventManager
    {

        public static readonly CustomEvent<GameDifficulty> OnDifficultySelected = new CustomEvent<GameDifficulty>();

        public static readonly CustomEvent<int> OnStartLevel = new CustomEvent<int>();

        public static readonly CustomEvent<int> OnCardSelected = new CustomEvent<int>();

        public static readonly CustomEvent<int> OnCorrectCardPicked = new CustomEvent<int>();

        public static readonly CustomEvent OnWrongCardPicked = new CustomEvent();
    }

}

