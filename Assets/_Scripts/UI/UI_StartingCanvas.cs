using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CyberSpeed.Matcher
{
    public class UI_StartingCanvas : MonoBehaviour
    {
        [SerializeField] Button _startButton;

        GameDifficulty _gameDifficulty;

        private void OnEnable()
        {
            _startButton.interactable = false;
            _startButton.onClick.AddListener(StartButtonPressed);
            EventManager.OnDifficultySelected.AddListener(OnDifficultySelected);
        }
        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartButtonPressed);
            EventManager.OnDifficultySelected.RemoveListener(OnDifficultySelected);
        }


        void StartButtonPressed()
        {
            _startButton.enabled = false;

            EventManager.OnStartLevel?.Invoke((int)_gameDifficulty);

        }


        void OnDifficultySelected(GameDifficulty gameDifficulty)
        {
            _gameDifficulty = gameDifficulty;

            if (!_startButton.interactable)
                _startButton.interactable = true;
        }

    }
}
