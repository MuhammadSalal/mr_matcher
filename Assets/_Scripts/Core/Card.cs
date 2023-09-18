using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CyberSpeed.Matcher
{
    public class Card : MonoBehaviour, ICard
    {
        Image _image;
        Button _button;

        CardData _cardData;

        private void OnEnable()
        {
            InitlizeComponents();
            _button.onClick.AddListener(OnButtonClick);

        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
        public void SetCard(CardData cardData)
        {
            _cardData = cardData;
            _image.sprite = _cardData.Sprite;
        }


        void OnButtonClick()
        {
            Debug.Log("Button Pressed");
        }



        void InitlizeComponents()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }


    }
}
