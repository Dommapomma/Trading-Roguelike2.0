using Palmmedia.ReportGenerator.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEditor.PlayerSettings;

public class MapMenuUI : MonoBehaviour
{
    public static MapMenuUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GenerateMap();
    }

    [SerializeField] private GameObject mapNodesParent;
    [SerializeField] private int doorWidth;
    [Serializable] public class mapNodePrefab
    {
        public MapNode node;
        public int probability = 1;
              
    }

    [SerializeField] private List<mapNodePrefab> mapNodePrefabs = new List<mapNodePrefab>();
    private List<MapNode> correctedMapNodePrefabs = new List<MapNode>();
    private void GenerateMap()
    {
        GenerateNodes();
    }
    private void GenerateNodes()
    {
        foreach (mapNodePrefab x in mapNodePrefabs)
        {
            for (int j = 0; j < x.probability; j++)
            {
                correctedMapNodePrefabs.Add(x.node);
            }
        }

        int doors = UnityEngine.Random.Range(1, 4);
        int pos = doorWidth / (doors + 1);
        for (int i = 1; i <= doors; i++)
        {
            int nodeIndex = UnityEngine.Random.Range(0, mapNodePrefabs.Count);
            MapNode node = Instantiate(correctedMapNodePrefabs[nodeIndex], mapNodesParent.transform);
            Vector3 vector3 = new Vector3(mapNodesParent.transform.position.x + (pos * i + 1), mapNodesParent.transform.position.y);
            node.transform.position = vector3;
        }
    }
}
