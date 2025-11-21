using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrb : BaseOrb
{
    [SerializeField] private SE_Electrocuted electrocutedEffect;
    [SerializeField] private int effectLength;
    public override void PlayOrb()
    {
        print("electric attack!");
        EnemyManager.Instance.Damage(damage);
        SE_Electrocuted statusEffect = Instantiate(electrocutedEffect, EnemyManager.Instance.GetStatusEffectParent().gameObject.transform);
        statusEffect.gameObject.transform.position = EnemyManager.Instance.GetStatusEffectParent().transform.position;
        statusEffect.SetEffectLength(effectLength);
        statusEffect.SetOwner(EnemyManager.Instance.gameObject);
        EnemyManager.Instance.AddStatusEffect(statusEffect);
        orbVisual.AttackVisual();
    }
    public override void InitializeOrb()
    {
        damage = 7;
    }
}
