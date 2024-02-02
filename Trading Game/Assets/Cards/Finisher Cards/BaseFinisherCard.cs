using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseFinisherCard : BaseCard
{
    [SerializeField] CardSO FinisherCardSO;
    [SerializeField] List<BaseOrb> requirements;

    [SerializeField] private int bonusDamage;
    [SerializeField] private int bonusHeal;
    [SerializeField] private int bonusCards;
    public override bool IPersistant {  get { return true; } }

    public override void PlayCard()
    {
        List<BaseOrb> inventory = Inventory.Instance.GetInventoryList();
        foreach (BaseOrb orb in requirements)
        {
            Type targetType = orb.GetType();
            foreach (BaseOrb orbToRemove in inventory)
            {
                if (orbToRemove.GetType() == targetType)
                {
                    orbToRemove.PlayOrb();
                    break;
                }
            }
        }
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }
    public virtual void FinisherBonus()
    {
        //extra bonus for playing finisher
    }
    public void DefaultFinisherBonus()
    {
        EnemyManager.Instance.Damage(bonusDamage);
        Player.Instance.Heal(bonusHeal);
        Player.Instance.DrawCards(bonusCards);
        FinisherBonus();
    }
    public override bool IsPlayable()//used by player script
    {
        List<BaseOrb> inventory = new List<BaseOrb>(Inventory.Instance.GetInventoryList());
        foreach (BaseOrb orb in requirements)
        {
            Type targetType = orb.GetType();
            // Use LINQ to check if the list contains an item of the specified type
            bool containsType = inventory.Where(item => item != null && item.GetType() == targetType).Any();
            if (!containsType)
            {
                return false;
            }
            else
            {
                print("found " + orb);
                foreach (BaseOrb orbToRemove in inventory)
                {
                    if (orbToRemove.GetType() == targetType) {
                        inventory.Remove(orbToRemove);
                        break;
                    }
                }
                
            }

        }
        return true;
    }
    public override void SetUpCard()
    {
        cardSO = FinisherCardSO;
    }
}
