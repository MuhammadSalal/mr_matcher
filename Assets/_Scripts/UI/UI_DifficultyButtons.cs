using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CyberSpeed.Matcher
{
    public class UI_DifficultyButtons : MonoBehaviour
    {
        [SerializeField] GameObject _tick;
        [SerializeField] GameDifficulty _difficulty;

        Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();

            _button.onClick.AddListener(ButtonPressed);
            EventManager.OnDifficultySelected.AddListener(OnDifficultySelected);
        }
        private void OnDisable()
        {
            EventManager.OnDifficultySelected.RemoveListener(OnDifficultySelected);
            _button.onClick.RemoveListener(ButtonPressed);
        }


        void OnDifficultySelected(GameDifficulty gameDifficulty)
        {
            bool state = _difficulty == gameDifficulty ? true : false;
            _tick.SetActive(state);

        }


        void ButtonPressed()
        {
            SoundManager.Singleton?.ButtonClick();
            EventManager.OnDifficultySelected?.Invoke(_difficulty);
        }
    }
}
