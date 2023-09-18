using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CyberSpeed.Matcher
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Tweening properties")]
        [SerializeField] Image _fadeImage;
        [SerializeField] float _fadeTime;

        [Header("Levels")]
        [SerializeField] string[] _levelNames;


        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        private void OnEnable()
        {
            EventManager.OnStartLevel.AddListener(OnStartLevel);
        }
        private void OnDisable()
        {
            EventManager.OnStartLevel.RemoveListener(OnStartLevel);
        }


        void OnStartLevel(int index)
        {
            FadeLoadLevel(index);
        }



        void FadeLoadLevel(int index)
        {
            _fadeImage.DOFade(1, _fadeTime).OnComplete(() =>
            {
                SceneManager.LoadScene(_levelNames[index]);
                UnFade();
            });
        }


        void UnFade()
        {
            _fadeImage.DOFade(0, _fadeTime);
        }
    }
}
