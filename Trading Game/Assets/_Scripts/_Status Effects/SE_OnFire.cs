using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_OnFire : _SE_Base
{
    //On fire entities take 5 damage per stack
    private int fireDamage = 5;
    public override void ApplyEffect(){
        if (owner.TryGetComponent(out IDamageable damageable))
        damageable.Damage(fireDamage);
        print("BURNY BURNY " + fireDamage);
        turns -= 1;
        IsDone();
    }
}
