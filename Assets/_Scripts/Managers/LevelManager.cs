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


        int _currentLevelIndex;
        string _startingSceneName;


        private void Awake()
        {
            _startingSceneName = "Starting Scene";
            DontDestroyOnLoad(this.gameObject);
        }
        private void OnEnable()
        {
            EventManager.OnStartLevel.AddListener(OnStartLevel);
            EventManager.OnAllCardsMatched.AddListener(OnAllCardsMatched);
            EventManager.OnBackToStartingScene.AddListener(OnBackToStartingScene);
        }
        private void OnDisable()
        {
            EventManager.OnStartLevel.RemoveListener(OnStartLevel);
            EventManager.OnAllCardsMatched.RemoveListener(OnAllCardsMatched);
            EventManager.OnBackToStartingScene.RemoveListener(OnBackToStartingScene);
        }

        #region EVENT_CALLBACKS
        void OnStartLevel(int index)
        {
            _currentLevelIndex = index;
            FadeLoadLevel(_currentLevelIndex, 0);
        }

        void OnAllCardsMatched()
        {
            FadeLoadLevel(_currentLevelIndex, 2);
        }

        void OnBackToStartingScene()
        {
            BackToStartingScene();
        }

        #endregion



        void FadeLoadLevel(int index, float delay)
        {
            _fadeImage.DOFade(1, _fadeTime).SetDelay(delay).OnComplete(() =>
            {
                SceneManager.LoadScene(_levelNames[index]);
                UnFade();
            });
        }

        void BackToStartingScene()
        {
            _fadeImage.DOFade(1, _fadeTime).OnComplete(() =>
            {
                SceneManager.LoadScene(_startingSceneName);
                UnFade();
            });
        }


        void UnFade()
        {
            _fadeImage.DOFade(0, _fadeTime);
        }
    }
}
