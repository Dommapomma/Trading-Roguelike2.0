using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEarthOrbCard : BaseCard
{
    [SerializeField] CardSO summonEarthOrbSO;
    [SerializeField] BaseOrb orb;
    public override void PlayCard()
    {

        Inventory.Instance.AddOrb(orb);
        print(this + "I am adding one fire orb");
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }


    public override void SetUpCard()
    {
        cardSO = summonEarthOrbSO;
    }
}
