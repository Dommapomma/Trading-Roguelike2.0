using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw2CardsAndGain1Mana : BaseCard
    //original name I know, does exactly what you think. Costs one mana to play and gives you one mana back so effectively costs 0 but you need atleast one mana to play it.
{
    [SerializeField] CardSO draw2CardsAndGain1ManaSO;
    public override void PlayCard() {

        Player.Instance.ChangeManaBy(1);
        Player.Instance.DrawCards(2);
        print(this + "I am drawing 2 more cards and gaining 1 mana");

        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }


    public override void SetUpCard() {
        cardSO = draw2CardsAndGain1ManaSO;
    }
}
