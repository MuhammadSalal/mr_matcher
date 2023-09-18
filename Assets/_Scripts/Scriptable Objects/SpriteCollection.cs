using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CyberSpeed.Matcher
{

    [CreateAssetMenu(menuName = "SO/Image Collection")]
    public class SpriteCollection : ScriptableObject
    {
        public Sprite[] Sprites;
    }
}
