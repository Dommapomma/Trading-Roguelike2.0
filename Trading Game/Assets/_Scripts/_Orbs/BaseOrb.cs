using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOrb : MonoBehaviour
{
    [SerializeField] protected int damage = 10;
    [SerializeField] protected OrbVisual orbVisual;

    public virtual void PlayOrb(){
        print("It's orbin' time!");
    }
    public int GetDamage(){
        return damage;
    }
}
