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

        Image _image;
        Button _button;
        CanvasGroup _canvasGroup;
        CardData _cardData;


        Vector3 _hideAngle;
        Vector3 _showAngle;

        private void OnEnable()
        {
            InitlizeComponents();
            _button.onClick.AddListener(OnButtonClick);

            EventManager.OnCorrectCardPicked.AddListener(OnCorrectCardPicked);
            EventManager.OnBackToStartingScene.AddListener(OnBackToStartingScene);

        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);

            EventManager.OnCorrectCardPicked.RemoveListener(OnCorrectCardPicked);
            EventManager.OnBackToStartingScene.RemoveListener(OnBackToStartingScene);
        }

        private void Start()
        {
            HideInitialCards();
        }


        #region INTERFACE_CONTRACTS

        public void SetCard(CardData cardData)
        {
            _cardData = cardData;

            SetSprite(_cardData.Sprite);

        }

        public void FlipShow()
        {
            ToggleButton(false);
            transform.DORotate(_hideAngle, _gameSettings.CardFlipDuration)
              .OnComplete(() =>
              {
                  SetSprite(_cardData.Sprite);
                  transform.DORotate(Vector3.zero, _gameSettings.CardFlipDuration);
              });
        }

        public void FlipNoMatch()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DORotate(_hideAngle, _gameSettings.CardFlipDuration).OnComplete(() =>
            {
                SetSprite(_cardData.Sprite);
            }));
            sequence.Append(transform.DORotate(_showAngle, _gameSettings.CardFlipDuration));


            sequence.Append(transform.DORotate(_hideAngle, _gameSettings.CardFlipDuration).SetDelay(_gameSettings.WrongCardShowDuration).OnComplete(() =>
            {
                SetSprite(_hideSprite);
            }));
            sequence.Append(transform.DORotate(_showAngle, _gameSettings.CardFlipDuration));
            sequence.OnComplete(() => ToggleButton(true));


        }

        public int GetID()
        {
            return _cardData.ID;
        }



        #endregion


        #region EVENT_CALLBACKS

        void OnCorrectCardPicked(int id)
        {
            if (_cardData.ID == id)
            {
                StartCoroutine(DisableCard(1));
            }
        }

        void OnBackToStartingScene()
        {
            ToggleButton(false);
        }

        #endregion

        void OnButtonClick()
        {
            SoundManager.Singleton?.CardFlip();
            ToggleButton(false);
            EventManager.OnCardSelected?.Invoke(this);

        }



        void InitlizeComponents()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _canvasGroup = GetComponent<CanvasGroup>();

            _hideAngle = new Vector3(0, 90, 0);
            _showAngle = Vector3.zero;
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


        IEnumerator DisableCard(float time)
        {
            yield return new WaitForSeconds(time);
            _canvasGroup.alpha = 0;
        }
    }
}
