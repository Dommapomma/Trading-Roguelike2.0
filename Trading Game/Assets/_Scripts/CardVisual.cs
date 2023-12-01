
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image frame;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image descriptionBackground;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private BaseCard card;

    private void Start() {
        UpdateVisual();
    }
    public void UpdateVisual() {
        title.text = card.GetCardName();
        cost.text = (card.GetManaCost()*-1).ToString();
        descriptionText.text = card.GetCardDescription();
    }
}
