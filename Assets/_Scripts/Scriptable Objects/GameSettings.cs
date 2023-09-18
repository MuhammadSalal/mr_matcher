using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{

    [CreateAssetMenu(menuName = "SO/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public float InitialCardShowTime;
        public float CardFlipDuration;

    }
}
