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

    }

}

