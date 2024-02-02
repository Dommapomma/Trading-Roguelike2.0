using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonFireOrbCard : BaseCard
    //fairly basic card for summoning a "more powerful cube". Costs 2 mana, creates a fire orb
{
    [SerializeField] CardSO summonFireOrbSO;
    [SerializeField] BaseOrb orb;
    public override void PlayCard() {

        Inventory.Instance.AddOrb(orb);
        print(this + "I am adding one fire orb");
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }


    public override void SetUpCard() {
        cardSO = summonFireOrbSO;
    }
}
