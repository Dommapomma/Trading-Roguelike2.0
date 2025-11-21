using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonOrb_Base : BaseCard
{
    [SerializeField] CardSO summonOrbSO;
    [SerializeField] BaseOrb orb;
    public override void PlayCard()
    {
        Inventory.Instance.AddOrb(orb);
        print(this + "I am adding one orb");
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }


    public override void SetUpCard()
    {
        cardSO = summonOrbSO;
    }
}
