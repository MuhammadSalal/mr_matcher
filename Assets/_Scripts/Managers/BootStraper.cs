
using UnityEngine;

namespace CyberSpeed.Matcher
{
    public class BootStraper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initlize() => Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("Systems")));
    }

}
