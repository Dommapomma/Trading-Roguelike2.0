using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserHealCard : BaseCard
{
    public override bool IConsumable { get { return true; } }
    public override bool IIntuitive { get { return true; } }
    [SerializeField] CardSO LesserHealCardSO;
    [SerializeField] int healAmount;
    public override void PlayCard()
    {
        Player.Instance.Heal(healAmount);
        print("Healing Player " +  healAmount);
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }


    public override void SetUpCard()
    {
        cardSO = LesserHealCardSO;
    }
}
