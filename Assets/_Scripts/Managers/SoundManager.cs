using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CyberSpeed.Matcher
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Singleton;

        [SerializeField] AudioSource audioSource;

        [Header("SO Refrence")]
        [SerializeField] SoundCollection _soundCollection;

        private void Awake()
        {
            if (Singleton == null)
                Singleton = this;
        }


        public void ButtonClick()
        {
            if (_soundCollection.ButtonClick.AudioClip == null)
                return;

            audioSource.PlayOneShot(_soundCollection.ButtonClick.AudioClip, _soundCollection.ButtonClick.Volume);

        }

        public void CardFlip()
        {
            if (_soundCollection.CardFlip.AudioClip == null)
                return;

            audioSource.PlayOneShot(_soundCollection.CardFlip.AudioClip, _soundCollection.CardFlip.Volume);
        }

        public void CardMatch()
        {
            if (_soundCollection.CardMatch.AudioClip == null)
                return;

            audioSource.PlayOneShot(_soundCollection.CardMatch.AudioClip, _soundCollection.CardMatch.Volume);
        }
        public void MissMatch()
        {
            if (_soundCollection.CardMissMatch.AudioClip == null)
                return;

            audioSource.PlayOneShot(_soundCollection.CardMissMatch.AudioClip, _soundCollection.CardMissMatch.Volume);
        }
        public void GameOver()
        {
            if (_soundCollection.GameOver.AudioClip == null)
                return;

            audioSource.PlayOneShot(_soundCollection.GameOver.AudioClip, _soundCollection.GameOver.Volume);
        }

    }
}
