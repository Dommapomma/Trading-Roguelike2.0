using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MundaneOrb : BaseOrb
{
    public override void InitializeOrb()
    {
        damage = 3;
    }
    public override void PlayOrb()
    {
        print("little poke!");
        EnemyManager.Instance.Damage(damage);
        orbVisual.AttackVisual();
    }
}
