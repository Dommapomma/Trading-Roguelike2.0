using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //keeping the inventory separate from the Player for now. Not sure if necessary though. Might be better to keep it all together on one script
    public static Inventory Instance {get; private set;}
    [SerializeField] private List<BaseOrb> inventory = new List<BaseOrb>();
    [SerializeField] private GameObject nrgCube;
    [SerializeField] private GameObject fireCube;
    [SerializeField] private int inventoryLength;
    [SerializeField] private int inventorySize;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        Debug.Log("Start");
    }
    private void Update() {
        inventoryLength = inventory.Count;
        UpdateInventoryVisual();
    }

    //Used by cards to make new orbs of various types.
    public void AddOrb(BaseOrb orb){
        inventory.Add(Instantiate(orb, this.gameObject.transform));
    }
    public List<BaseOrb> GetInventoryList(){
        return inventory;
    }
    private void UpdateInventoryVisual() {
        for (int i = 0; i < inventory.Count; i++) {
            int column = Mathf.FloorToInt(i/5);
            int row = Mathf.FloorToInt(i%5);
            Vector2 vector2 = new Vector2(this.transform.position.x - (100 * column), this.transform.position.y + ((120 * row)));
            inventory[i].transform.position = vector2;
        }
    }

    public void RemoveOrbFromInventory(BaseOrb orb){
        inventory.Remove(orb);
    }
}
