using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseFinisherCard : BaseCard
{
    [SerializeField] CardSO BaseFinisherCardSO;
    [SerializeField] List<BaseOrb> requirements;
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
                    orb.PlayOrb();
                    break;
                }
            }

        }
        Player.Instance.ChangeManaBy(cardSO.manaCost);

    }
    public override bool IsPlayable()
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
        cardSO = BaseFinisherCardSO;
    }
}
