using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CardSO : ScriptableObject {
    //All cubes get their name and mana cost from their scriptable object. not sure what use storing the prefab is but maybe could be useful at some point.

    [SerializeField] public string cardName;
    [SerializeField] public string cardDescription;
    [SerializeField] public int manaCost;
    [SerializeField] public BaseCard card;
}
