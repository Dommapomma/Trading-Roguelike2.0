using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MapNodeSO : ScriptableObject
{
    [SerializeField] public string nodeName;
    [SerializeField] public SceneLoader.Scene scene;
    [SerializeField] public BaseEnemy enemy;
}