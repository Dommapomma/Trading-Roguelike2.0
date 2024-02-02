using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartConditionSetter : MonoBehaviour
{
    [SerializeField] private string WARNING = "Only have ONE of these between all scenes";
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
        if (PlayerSave.savedStartingCards.Count == 0) {
            foreach (BaseCard card in setStartingDeck)
            {
                PlayerSave.savedStartingCards.Add(card);
            }
        } else
        {
            Debug.LogError("There were already cards in the player's hand. You likely have more than one start condition setter in your scenes");
        }
        
    }
    private void RemoveUnusedVariableWarning()
    {
        WARNING += "";
    }
}
