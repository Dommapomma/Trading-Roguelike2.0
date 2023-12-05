using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMenuUI : MonoBehaviour
{
    [SerializeField] private Button poisonButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button confirmButton;

    [SerializeField] private BaseEnemy fireEnemy;
    [SerializeField] private BaseEnemy poisonEnemy;

    private void Awake()
    {
        poisonButton.onClick.AddListener(() =>
        {
            EnemyType.enemyType = poisonEnemy;
        });
        fireButton.onClick.AddListener(() =>
        {
            EnemyType.enemyType = fireEnemy;
        });
        confirmButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.GameScene);
        });
    }
    private void Start()
    {
        EnemyType.enemyType = poisonEnemy;
    }
}
