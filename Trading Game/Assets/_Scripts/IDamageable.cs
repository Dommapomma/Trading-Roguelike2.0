using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(int damage);
}
public interface IStatusEffectable
{
    void AddStatusEffect(_SE_Base statusEffect);
    void RemoveStatusEffect(_SE_Base statusEffect);
    GameObject GetStatusEffectParent();
    List<_SE_Base> GetStatusEffectList();
}
public interface IMissable
{
    List<int> MissChances { get;}
    bool MissedAction();
    void AddMissChance(int missChance);
    void RemoveMissChance(int missChance);

}
