using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GainCardUI : MonoBehaviour
{
    [SerializeField] private List<BaseCard> possibleCards = new List<BaseCard>();
    [SerializeField] private List<CardOption> cardOptions = new List<CardOption>();

    [SerializeField] private Button card1Button;
    [SerializeField] private Button card2Button;
    [SerializeField] private Button card3Button;

    [Serializable]
    public class CardOption
    {
        public Button button;
        public BaseCard card;

        public CardOption(Button button, BaseCard card)
        {
            this.button = button;
            this.card = card;
        }
    }
    private void Awake()
    {
        cardOptions.Add(new CardOption(card1Button, possibleCards[UnityEngine.Random.Range(0, possibleCards.Count)]));
        cardOptions.Add(new CardOption(card2Button, possibleCards[UnityEngine.Random.Range(0, possibleCards.Count)]));
        cardOptions.Add(new CardOption(card3Button, possibleCards[UnityEngine.Random.Range(0, possibleCards.Count)]));
    }
    private void Start()
    {
        foreach (CardOption cardOption in cardOptions)
        {
            BaseCard card = Instantiate(cardOption.card, this.transform);
            
            if (cardOption.button.GetComponentInChildren<TextMeshProUGUI>().text == null)
            {
                print("null");
            } else
            {
                print("not null");
                if (card != null)
                {
                    print(card.GetCardName());
                }
                string cardName = card.GetCardName();
                card.Hide();
                cardOption.button.GetComponentInChildren<TextMeshProUGUI>().text = cardName;
            }

            cardOption.button.onClick.AddListener(() =>
            {
                print("adding");
                PlayerSave.savedStartingCards.Add(cardOption.card);
                //SceneLoader.Load(SceneLoader.Scene.MapScene);
            });
        }
    }
}
