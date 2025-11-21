using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthOrb : BaseOrb
{
    public override void InitializeOrb()
    {
        damage = 7;
    }
    //[SerializeField] private SE_ fireEffect;
    //[SerializeField] private int effectLength;
    public override void PlayOrb()
    {
        print("earth attack!");
        EnemyManager.Instance.Damage(damage);
        /*SE_OnFire statusEffect = Instantiate(fireEffect, EnemyManager.Instance.GetStatusEffectParent().gameObject.transform);
        statusEffect.gameObject.transform.position = EnemyManager.Instance.GetStatusEffectParent().transform.position;
        statusEffect.SetEffectLength(effectLength);
        statusEffect.SetOwner(EnemyManager.Instance.gameObject);
        EnemyManager.Instance.AddStatusEffect(statusEffect);*/
        orbVisual.AttackVisual();
    }
}
