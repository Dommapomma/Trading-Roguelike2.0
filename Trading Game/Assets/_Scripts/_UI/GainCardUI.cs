using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MapMenuUI;

public class GainCardUI : MonoBehaviour
{
    [SerializeField] private List<cardOptionPrefab> possibleCards = new List<cardOptionPrefab>();
    private List<BaseCard> correctedPossibleCards = new List<BaseCard>();
    [SerializeField] private List<CardOption> cardOptions = new List<CardOption>();

    [SerializeField] private Button card1Button;
    [SerializeField] private Button card2Button;
    [SerializeField] private Button card3Button;


    [Serializable]
    public class cardOptionPrefab
    {
        public BaseCard card;
        public int probability = 1;
    }
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
        foreach (cardOptionPrefab x in possibleCards)
        {
            for (int j = 0; j < x.probability; j++)
            {
                correctedPossibleCards.Add(x.card);
            }
        }
        cardOptions.Add(new CardOption(card1Button, correctedPossibleCards[UnityEngine.Random.Range(0, correctedPossibleCards.Count)]));
        cardOptions.Add(new CardOption(card2Button, correctedPossibleCards[UnityEngine.Random.Range(0, correctedPossibleCards.Count)]));
        cardOptions.Add(new CardOption(card3Button, correctedPossibleCards[UnityEngine.Random.Range(0, correctedPossibleCards.Count)]));
    }
    private void Start()
    {
        foreach (CardOption cardOption in cardOptions)
        {
            BaseCard card = Instantiate(cardOption.card, this.transform);
            
            cardOption.button.GetComponentInChildren<TextMeshProUGUI>().text = card.GetCardName(); ;
            cardOption.button.onClick.AddListener(() =>
            {
                PlayerSave.savedStartingCards.Add(cardOption.card);
                SceneLoader.Load(SceneLoader.Scene.MapScene);
            });
        }
    }
}
