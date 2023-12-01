using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAttackCard : BaseCard
{
    [SerializeField] CardSO darkAttackSO;
    public override void PlayCard(){
        /*List<BaseOrb> inventory = Inventory.Instance.GetInventoryList();
        List<DarkOrb> darkOrbs = new List<DarkOrb>();
        foreach (DarkOrb darkOrb in inventory){
            darkOrbs.Add(darkOrb);
        }
        foreach (DarkOrb darkOrb in darkOrbs){
            darkOrb.PlayOrb();
        }
        darkOrbs.Clear();
        print(this + "I attacking with dark orbs");
        Player.Instance.ChangeManaBy(cardSO.manaCost);*/

        List<BaseOrb> inventory = Inventory.Instance.GetInventoryList();
        List<BaseOrb> baseOrbs = new List<BaseOrb>();
        foreach (BaseOrb baseOrb in inventory){
            baseOrbs.Add(baseOrb);
        }
        foreach (BaseOrb baseOrb in baseOrbs){
            baseOrb.PlayOrb();
        }
        baseOrbs.Clear();
        print(this + "I attacking with all orbs");
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }
    public override void SetUpCard() {
        cardSO = darkAttackSO;
    }
}
