using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfoExposer : MonoBehaviour
{
    [SerializeField] private string IMPORTANT = "These are READ-ONLY, DO NOT EDIT";
    [SerializeField] private bool exposedInfoUpdate = true;
    [SerializeField] private BaseEnemy nextEnemy;
    [SerializeField] private List<BaseCard> savedStartingCards = new List<BaseCard>();
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    

    private void getInfo()
    {
        nextEnemy = EnemyType.enemyType;
        savedStartingCards = PlayerSave.savedStartingCards;
        health = PlayerSave.health;
        maxHealth = PlayerSave.maxHealth;
        
    }
    private void Update()
    {
        if (exposedInfoUpdate == true)
        {
            exposedInfoUpdate = false;
            getInfo();
        }
    }
    private void RemoveUnusedVariableWarning()
    {
        IMPORTANT += "";
    }
}
