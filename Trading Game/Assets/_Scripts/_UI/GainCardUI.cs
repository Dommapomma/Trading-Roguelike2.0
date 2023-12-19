using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static MapMenuUI;

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

            if (cardOption.button.GetComponentInChildren<TextMeshProUGUI>().text == null)
            {
                print("null");
            } else
            {
                print("not null");
                BaseCard card = Instantiate(cardOption.card);
                string name = card.GetCardName();
                card.Hide();
                cardOption.button.GetComponentInChildren<TextMeshProUGUI>().text = name;
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
