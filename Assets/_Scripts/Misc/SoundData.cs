using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    [System.Serializable]
    public class SoundData
    {
        public AudioClip AudioClip;
        [Range(0, 1)] public float Volume;
    }
}
