using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseTraderCard : BaseCard
{
    public BaseTraderCard()
    {
        ITrader = true;
    }

    [SerializeField] CardSO FinisherCardSO;
    [SerializeField] List<BaseOrb> input;
    [SerializeField] List<BaseOrb> output;

    public override void PlayCard()
    {
        List<BaseOrb> inventory = Inventory.Instance.GetInventoryList();
        foreach (BaseOrb orb in input)
        {
            Type targetType = orb.GetType();
            foreach (BaseOrb orbToRemove in inventory)
            {
                if (orbToRemove.GetType() == targetType)
                {
                    Inventory.Instance.RemoveOrbFromInventory(orbToRemove);
                    break;
                }
            }
        }
        foreach (BaseOrb gainOrb in output)
        {
            Inventory.Instance.AddOrb(gainOrb);
        }

        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }
    public override bool IsPlayable()//used by player script
    {
        List<BaseOrb> inventory = new List<BaseOrb>(Inventory.Instance.GetInventoryList());
        foreach (BaseOrb orb in input)
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
                    if (orbToRemove.GetType() == targetType)
                    {
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
