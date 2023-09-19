using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CyberSpeed.Matcher
{
    public class UI_GamePlayCanvas : MonoBehaviour
    {
        [Header("Notifications Refrence")]
        [SerializeField] TextMeshProUGUI _scoreText;
        [SerializeField] TextMeshProUGUI _matchesText;
        [SerializeField] TextMeshProUGUI _turnsText;

        [Header("Back button")]
        [SerializeField] Button _backButton;

        [Header("SO Refrence")]
        [SerializeField] GameSettings _gameSettings;

        SaveData _saveData;

        int _scoreCount;
        int _matchCount;
        int _turnCount;

        private void OnEnable()
        {
            InitlizeValues();

            _backButton.onClick.AddListener(OnBackButtonPressed);
            EventManager.OnCorrectCardPicked.AddListener(OnCorrectCardPicked);
            EventManager.OnWrongCardPicked.AddListener(OnWrongCardPicked);
            EventManager.OnAllCardsMatched.AddListener(OnAllCardsMatched);
        }
        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonPressed);
            EventManager.OnCorrectCardPicked.RemoveListener(OnCorrectCardPicked);
            EventManager.OnWrongCardPicked.RemoveListener(OnWrongCardPicked);
            EventManager.OnAllCardsMatched.RemoveListener(OnAllCardsMatched);
        }


        #region EVENT_CALLBACKS

        void OnCorrectCardPicked(int Id)
        {
            _turnCount++;
            _scoreCount += _gameSettings.ScorePerCorrectMatch;
            _matchCount++;

            UpdateScoreText();
            UpdateMatchText();
            UpdateTurnsText();
        }

        void OnWrongCardPicked()
        {
            _turnCount++;
            UpdateTurnsText();

        }

        void OnAllCardsMatched()
        {
            _backButton.enabled = false;
        }

        #endregion

        void OnBackButtonPressed()
        {
            _backButton.enabled = false;
            EventManager.OnBackToStartingScene?.Invoke();
        }


        void InitlizeValues()
        {
            _saveData = SaveManager.GetJsonFile();
            _scoreCount = _saveData.Score;

            UpdateScoreText();
            UpdateMatchText();
            UpdateTurnsText();
        }


        void UpdateScoreText()
        {
            _scoreText.text = $"Score: {_scoreCount}";
        }
        void UpdateMatchText()
        {
            _matchesText.text = $"Matches: {_matchCount}";
        }
        void UpdateTurnsText()
        {
            _turnsText.text = $"Turns: {_turnCount}";
        }
    }
}
