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

    [SerializeField] private int seed = 0;
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

    [SerializeField]

    private void GenerateMap()
    {
        SetSeed();
        //Instantiate(Map)

    }
    private void SetSeed()
    {
        if (seed == 0)
        {
            seed = Random.Range(1000000, 9999999);     
        }
        Random.InitState(seed);
    }



}
