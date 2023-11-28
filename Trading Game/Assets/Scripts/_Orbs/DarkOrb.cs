using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class DarkOrb : BaseOrb
{
    private void Start() {
        damage = 15;
    }
    public override void PlayOrb(){
        print("dark attack!");
        Inventory.Instance.RemoveOrbFromInventory(this);
        EnemyManager.Instance.Damage(damage);
        orbVisual.AttackVisual();
    }
}
