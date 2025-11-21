using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class DarkOrb : BaseOrb
{
    public override void InitializeOrb() {
        damage = 15;
    }
    public override void PlayOrb(){
        print("dark attack!");
        EnemyManager.Instance.Damage(damage);
        orbVisual.AttackVisual();
    }
}
