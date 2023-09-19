using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    public class ConfettiManager : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particle;

        private void OnEnable()
        {
            EventManager.OnAllCardsMatched.AddListener(OnAllCardsMatched);
        }
        private void OnDisable()
        {
            EventManager.OnAllCardsMatched.RemoveListener(OnAllCardsMatched);
        }

        void OnAllCardsMatched()
        {
            _particle.Play();
        }


    }
}
