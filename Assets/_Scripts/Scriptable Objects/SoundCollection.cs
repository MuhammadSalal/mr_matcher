using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    [CreateAssetMenu(menuName = "SO/Sound Collection")]
    public class SoundCollection : ScriptableObject
    {
        public SoundData ButtonClick;
        public SoundData CardFlip;
        public SoundData CardMatch;
        public SoundData CardMissMatch;
        public SoundData GameOver;

    }
}
