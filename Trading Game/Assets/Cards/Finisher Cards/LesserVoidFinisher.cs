using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserVoidFinisher : BaseFinisherCard
{
    [SerializeField] private int extraDamage = 20;
    public override void FinisherBonus()
    {
        EnemyManager.Instance.Damage(extraDamage);
    }
}
