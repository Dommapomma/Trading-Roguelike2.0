using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Electrocuted : _SE_Base
{
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
