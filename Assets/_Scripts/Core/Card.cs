using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CyberSpeed.Matcher
{
    public class Card : MonoBehaviour, ICard
    {
        [SerializeField] Sprite _hideSprite;

        [Header("SO Refrence")]
        [SerializeField] GameSettings _gameSettings;

        int _currentSelectedID;

        Image _image;
        Button _button;
        CardData _cardData;
        Vector3 _hideAngle;

        private void OnEnable()
        {
            InitlizeComponents();
            _button.onClick.AddListener(OnButtonClick);

        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void Start()
        {
            HideInitialCards();
        }

        public void SetCard(CardData cardData)
        {
            _cardData = cardData;

            SetSprite(_cardData.Sprite);

        }


        void OnButtonClick()
        {
            Debug.Log("Button Pressed");
            ToggleButton(false);
            EventManager.OnCardSelected?.Invoke(_cardData.ID);
            ShowCard();
        }



        void InitlizeComponents()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();

            _hideAngle = new Vector3(0, 90, 0);
        }

        void HideInitialCards()
        {
            ToggleButton(false);
            transform.DORotate(_hideAngle, _gameSettings.CardFlipDuration)
                .SetDelay(_gameSettings.InitialCardShowTime)
                .OnComplete(() =>
                {
                    SetSprite(_hideSprite);
                    transform.DORotate(Vector3.zero, _gameSettings.CardFlipDuration).OnComplete(() => ToggleButton(true));
                });
        }

        void ToggleButton(bool state)
        {
            _button.enabled = state;
        }


        void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        void ShowCard()
        {
            transform.DORotate(_hideAngle, _gameSettings.CardFlipDuration)
               .OnComplete(() =>
               {
                   SetSprite(_cardData.Sprite);
                   transform.DORotate(Vector3.zero, _gameSettings.CardFlipDuration).OnComplete(() => ToggleButton(true));
               });
        }
    }
}
