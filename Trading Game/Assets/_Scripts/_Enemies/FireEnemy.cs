using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : BaseEnemy
{
    [SerializeField] private SE_OnFire onFireEffect;
    [SerializeField] private int enemyDamage = 15;
    private void Start()
    {
        InitializeAttacks();
    }
    private void FireAttack()
    {
        print("Poison");
        SE_OnFire statusEffect = Instantiate(onFireEffect, Player.Instance.GetStatusEffectParent().gameObject.transform);
        statusEffect.gameObject.transform.position = Player.Instance.GetStatusEffectParent().transform.position;
        statusEffect.SetEffectLength(5);
        statusEffect.SetOwner(Player.Instance.gameObject);
        Player.Instance.AddStatusEffect(statusEffect);
    }
    private void Stab()
    {
        print("Stab");
        Player.Instance.Damage(enemyDamage);
    }
    protected override void InitializeAttacks()
    {
        attackFunctions = new AttackFunction[] { FireAttack, Stab };
    }
}
