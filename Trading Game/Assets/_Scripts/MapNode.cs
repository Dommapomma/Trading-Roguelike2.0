using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    [SerializeField] private MapNode mapNode;
    [SerializeField] private int generation = 0;

    private void Start()
    {
        if (generation <= 5)
        {
            int childNodes = Random.Range(1, 3);
            for (int i = 0; i < childNodes; i++)
            {
                MapNode node = Instantiate(mapNode, this.transform);
                node.SetGeneration(generation++);
            }
        }
    }
    public void SetGeneration(int gen)
    {
        generation = gen;
    }
}
