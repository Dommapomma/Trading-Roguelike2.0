using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseOrb : MonoBehaviour
{
    [SerializeField] protected int damage = 5;
    [SerializeField] protected OrbVisual orbVisual;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayOrb);
        InitializeOrb();
    }
    public virtual void InitializeOrb()
    {

    }
    public virtual void PlayOrb(){
        print("It's orbin' time!");
    }
    public int GetDamage(){
        return damage;
    }
}
