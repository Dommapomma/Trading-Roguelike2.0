using Palmmedia.ReportGenerator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MapMenuUI : MonoBehaviour
{
    [SerializeField] private Button poisonButton;
    [SerializeField] private Button fireButton;
    [SerializeField] private Button confirmButton;

    [SerializeField] private BaseEnemy fireEnemy;
    [SerializeField] private BaseEnemy poisonEnemy;
    //[SerializeField] private Node rootNode;
    //[SerializeField] public List<Node> nodes = new List<Node>();
    //[SerializeField] private MapNode mapNode;

    public static MapMenuUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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
        //rootNode = new Node(0, this.gameObject);
        EnemyType.enemyType = poisonEnemy;
        GenerateMap();
    }

    [SerializeField] private int seed = 0;
    [SerializeField] private MapNode rootNode;
    private void GenerateMap()
    {
        SetSeed();
        Instantiate(rootNode, transform).Generate();
        //nodes.Add(rootNode);
        //rootNode.Generate(mapNode);

    }
    /*[Serializable]
    public class Node
    {
        private int generation = 0;
        [SerializeField] private List<Node> childNodeList = new List<Node>();
        private bool hasGenerated = false;
        private GameObject parentNode;

        public Node(int c_generation, GameObject c_parentNode)
        {
            generation = c_generation;
            parentNode = c_parentNode;
        }
        public void Generate(MapNode mapNode)
        {
            GameObject currentNode = Instantiate(mapNode, parentNode.gameObject.transform).gameObject;
            if (generation <= 4 && hasGenerated == false)
            {
                int childNodes = UnityEngine.Random.Range(1, 3);
                for (int i = 0; i < childNodes; i++)
                {
                    Node node = new Node(generation + 1, currentNode);
                    childNodeList.Add(node);
                    childNodeList[i].Generate(mapNode);
                }
                hasGenerated = true;
            }
        }
    }*/

    private void SetSeed()
    {
        if (seed == 0)
        {
            seed = UnityEngine.Random.Range(1000000, 9999999);
        }
        UnityEngine.Random.InitState(seed);
    }

}
