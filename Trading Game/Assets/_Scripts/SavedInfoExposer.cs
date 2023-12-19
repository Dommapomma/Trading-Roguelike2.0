using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfoExposer : MonoBehaviour
{
    [SerializeField] private BaseEnemy nextEnemy;
    [SerializeField] private List<BaseCard> savedStartingCards = new List<BaseCard>();

    private void Start()
    {
        nextEnemy = EnemyType.enemyType;
        savedStartingCards = PlayerSave.savedStartingCards;
    }
}
