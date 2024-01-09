using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    #region OldMapSystem
    /*
    [SerializeField] private MapNode mapNode;
    [SerializeField] private int generation = 0;
    [SerializeField] private List<MapNode> childNodeList = new List<MapNode>();
    private bool hasGenerated = false;

    public void Generate()
    {
        if (generation <= 4 && hasGenerated == false)
        {
            print(generation);
            int childNodes = Random.Range(1, 3);
            for (int i = 0; i < childNodes; i++)
            {
                childNodeList.Add(Instantiate(mapNode, this.transform));
                childNodeList[i].SetGeneration(generation + 1);
                childNodeList[i].Generate();
            }
            hasGenerated = true;
        }
    }
    public void SetGeneration(int gen)
    {
        generation = gen;
    }*/
    #endregion

    [SerializeField] MapNodeSO mapNodeSO;
    [SerializeField] Button door;
    [SerializeField] TextMeshProUGUI doorText;
    private void Awake()
    {
        door.onClick.AddListener(() =>
        {
            if (mapNodeSO.enemy != null)
            {
                EnemyType.enemyType = mapNodeSO.enemy;
            }
            if (mapNodeSO.nodeName != null)
            {
                doorText.text = mapNodeSO.nodeName;
            }
            SceneLoader.Load(mapNodeSO.scene);
        });
    }
}
