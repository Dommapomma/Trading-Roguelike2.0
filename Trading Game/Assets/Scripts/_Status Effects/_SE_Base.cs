using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class _SE_Base : MonoBehaviour
{
    [SerializeReference] protected GameObject owner;
    [SerializeField] protected int turns = 3;

    public virtual void ApplyEffect(){
        print("Im doing my effect");
        turns -= 1;
        IsDone();
    }
    public void SetEffectLength(int effectLength){
        turns = effectLength;
    }
    public void SetOwner(GameObject newOwner){
        owner = newOwner;
    }
    protected void IsDone(){
        if (turns <= 0){
            if (owner.TryGetComponent(out IStatusEffectable statusEffectable))
            statusEffectable.RemoveStatusEffect(this);
            Destroy(this.gameObject);
        }
    }
}
