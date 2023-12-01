using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SummonDarkOrbCard : BaseCard
    //basic card for summoning one regular cube, costs 1 mana, creates 1 basic cube
{
    [SerializeField] CardSO summonDarkOrbSO;
    [SerializeField] BaseOrb orb;
    public override void PlayCard(){

        Inventory.Instance.AddOrb(orb);
        print(this + "I am adding one cube");
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }
    public override void SetUpCard() {
        cardSO = summonDarkOrbSO;
    }
}
