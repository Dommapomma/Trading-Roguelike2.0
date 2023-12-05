using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FireOrb : BaseOrb
{
    [SerializeField] private SE_OnFire fireEffect;
    [SerializeField] private int effectLength;
    public override void PlayOrb(){
        print("fire attack!");
        Inventory.Instance.RemoveOrbFromInventory(this);
        EnemyManager.Instance.Damage(damage);
        SE_OnFire statusEffect = Instantiate(fireEffect, EnemyManager.Instance.GetStatusEffectParent().gameObject.transform);
        statusEffect.gameObject.transform.position = EnemyManager.Instance.GetStatusEffectParent().transform.position;
        statusEffect.SetEffectLength(effectLength);
        statusEffect.SetOwner(EnemyManager.Instance.gameObject);
        EnemyManager.Instance.AddStatusEffect(statusEffect);
        orbVisual.AttackVisual();
    }
}
