using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedInfoExposer : MonoBehaviour
{
    [SerializeField] private bool exposedInfoUpdate = true;
    [SerializeField] private BaseEnemy nextEnemy;
    [SerializeField] private List<BaseCard> savedStartingCards = new List<BaseCard>();

    private void getInfo()
    {
        nextEnemy = EnemyType.enemyType;
        savedStartingCards = PlayerSave.savedStartingCards;
    }
    private void Update()
    {
        if (exposedInfoUpdate == true)
        {
            exposedInfoUpdate = false;
            getInfo();
        }
    }
}
