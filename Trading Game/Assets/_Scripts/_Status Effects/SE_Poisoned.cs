using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Poisoned : _SE_Base
{
    //Poisoned entities take 1 damage per stack, per stack
    private int poisonDamage;
    public override void ApplyEffect(){
        poisonDamage = 0;
        foreach (_SE_Base effect in Player.Instance.GetStatusEffectList()){
            if (effect.GetType() == typeof(SE_Poisoned)){
                poisonDamage += 1;
            }
        }
        if (owner.TryGetComponent(out IDamageable damageable))
        damageable.Damage(poisonDamage);
        turns -= 1;
        IsDone();
    }
}
