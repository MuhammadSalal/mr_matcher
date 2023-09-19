using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CyberSpeed.Matcher
{
    public class UI_GamePlayCanvas : MonoBehaviour
    {
        [Header("Notifications Refrence")]
        [SerializeField] TextMeshProUGUI _scoreText;
        [SerializeField] TextMeshProUGUI _matchesText;
        [SerializeField] TextMeshProUGUI _turnsText;

        [Header("SO Refrence")]
        [SerializeField] GameSettings _gameSettings;

        SaveData _saveData;

        int _scoreCount;
        int _matchCount;
        int _turnCount;

        private void OnEnable()
        {
            InitlizeValues();

            EventManager.OnCorrectCardPicked.AddListener(OnCorrectCardPicked);
            EventManager.OnWrongCardPicked.AddListener(OnWrongCardPicked);
        }
        private void OnDisable()
        {
            EventManager.OnCorrectCardPicked.RemoveListener(OnCorrectCardPicked);
            EventManager.OnWrongCardPicked.RemoveListener(OnWrongCardPicked);
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

        #endregion


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
