using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Electrocuted : _SE_Base
{
    //Electrocuted enemies have a 20% chance to fail their action for each stack
    //Electrocuted players draw 1 less card for each stack
    bool used = false;
    public override void ApplyEffect()
    {

        if (owner.TryGetComponent(out Player playerOwner) && used == false)
        {
            Player.Instance.ChangeDrawHandSize(-1);
            used = true;
        } else if (owner.TryGetComponent(out EnemyManager enemy))
        {
            enemy.AddMissChance(20);
            used = true;
        }
        turns -= 1;
        IsDone();
    }
    protected override void IsDoneEffect()
    {
        if (owner.TryGetComponent(out Player playerOwner))
        {
            Player.Instance.ChangeDrawHandSize(1);
        } else if (owner.TryGetComponent(out EnemyManager enemy))
        {
            enemy.RemoveMissChance(20);
        }
    }
}
