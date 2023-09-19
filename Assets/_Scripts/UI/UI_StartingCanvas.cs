using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CyberSpeed.Matcher
{
    public class UI_StartingCanvas : MonoBehaviour
    {
        [SerializeField] Button _startButton;
        [SerializeField] TextMeshProUGUI _scoreText;
        [SerializeField] TextMeshProUGUI _levelText;


        GameDifficulty _gameDifficulty;
        SaveData _saveData;

        private void Start()
        {
            SetScorePanel();
        }
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

            SoundManager.Singleton?.ButtonClick();
            EventManager.OnStartLevel?.Invoke((int)_gameDifficulty);

        }


        void OnDifficultySelected(GameDifficulty gameDifficulty)
        {
            _gameDifficulty = gameDifficulty;

            if (!_startButton.interactable)
                _startButton.interactable = true;
        }


        void SetScorePanel()
        {
            _saveData = SaveManager.GetJsonFile();

            _scoreText.text = $"Total Score {_saveData.Score}";
            _levelText.text = $"Levels Completed {_saveData.LevelsCompleted}";
        }
    }
}
