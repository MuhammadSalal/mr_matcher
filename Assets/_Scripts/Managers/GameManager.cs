using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CyberSpeed.Matcher
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameDifficulty _gameDifficulty;
        [SerializeField] GameObject _foodPanel;

        [Header("SO Refrence")]
        [SerializeField] SpriteCollection _spriteCollection;


        List<Sprite> _newSpriteCollection;
        List<ICard> _cardsColleciton;
        List<CardData> _cardDatas;
        int _ConnectedCards;

        int _currentSelectedID;
        private void Awake()
        {
            GetCards();
            InitlizeValues();
        }
        private void Start()
        {
            SetupCards();
        }

        private void OnEnable()
        {
            EventManager.OnCardSelected.AddListener(OnCardSelected);
        }
        private void OnDisable()
        {
            EventManager.OnCardSelected.RemoveListener(OnCardSelected);
        }


        #region EVENT_CALLBACKS

        void OnCardSelected(int Id)
        {
            if (_currentSelectedID == 0)
            {
                _currentSelectedID = Id;
                return;
            }

            if (_currentSelectedID == Id)
            {
                Debug.Log("Correct Card Picked!");
                _currentSelectedID = 0;
            }
            else
            {
                Debug.Log("Wrong Card Picked");
            }

        }


        #endregion


        void GetCards()
        {
            ICard[] cards = _foodPanel.GetComponentsInChildren<ICard>();
            _cardsColleciton = new List<ICard>(cards.ToList());
        }
        void InitlizeValues()
        {
            _ConnectedCards = _cardsColleciton.Count / 2;
            _newSpriteCollection = new List<Sprite>(_spriteCollection.Sprites.ToList());
            _cardDatas = new List<CardData>();

            for (int i = 0; i < _ConnectedCards; i++)
            {
                CardData cardData = new CardData((i + 1), GetSprite());

                _cardDatas.Add(cardData);
                _cardDatas.Add(cardData);
            }


        }
        void SetupCards()
        {
            int totalCards = _cardsColleciton.Count;

            for (int i = 0; i < totalCards; i++)
            {
                ICard card = GetCard();
                card.SetCard(_cardDatas[i]);
            }

        }

        Sprite GetSprite()
        {
            int randomIndex = Random.Range(0, _newSpriteCollection.Count);
            Sprite sprite = _newSpriteCollection[randomIndex];
            _newSpriteCollection.RemoveAt(randomIndex);
            return sprite;

        }


        ICard GetCard()
        {
            int randomIndex = Random.Range(0, _cardsColleciton.Count);
            ICard card = _cardsColleciton[randomIndex];
            _cardsColleciton.RemoveAt(randomIndex);
            return card;
        }



    }
}
