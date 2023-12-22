using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConditionSetter : MonoBehaviour
{
    [SerializeField] private List<BaseCard> setStartingDeck = new List<BaseCard>();
    [SerializeField] private int maxHealth;
    private void Awake()
    {
        SetStartingDeck();
        PlayerSave.health = maxHealth;
        PlayerSave.maxHealth = maxHealth;
    }

    private void SetStartingDeck()
    {
        foreach (BaseCard card in setStartingDeck)
        {
            PlayerSave.savedStartingCards.Add(card);
        }
    }
}
