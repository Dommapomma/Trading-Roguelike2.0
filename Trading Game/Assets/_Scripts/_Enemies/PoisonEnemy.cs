using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEnemy : BaseEnemy
{
    [SerializeField] private SE_Poisoned poisonedEffect;
    [SerializeField] private int enemyDamage = 5;
    [SerializeField] private int healAmount = 10;
    private void Start()
    {
        InitializeAttacks();
    }
    private void PoisonAttack()
    {
        print("Poison");
        SE_Poisoned statusEffect = Instantiate(poisonedEffect, Player.Instance.GetStatusEffectParent().gameObject.transform);
        statusEffect.gameObject.transform.position = Player.Instance.GetStatusEffectParent().transform.position;
        statusEffect.SetEffectLength(3);
        statusEffect.SetOwner(Player.Instance.gameObject);
        Player.Instance.AddStatusEffect(statusEffect);
    }
    private void Heal()
    {
        print("Heal");
        EnemyManager.Instance.Heal(healAmount);
    }
    private void Stab()
    {
        print("Stab");
        Player.Instance.Damage(enemyDamage);
    }
    protected override void InitializeAttacks()
    {
        attackFunctions = new AttackFunction[] { PoisonAttack, Heal, Stab };
    }
}
