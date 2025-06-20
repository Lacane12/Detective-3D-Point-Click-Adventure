using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "InventorySystem/Item", order = 1)]
public class inventoryItem: ScriptableObject
{
    public string itemId;
    public GameObject itemObject;
    [Space(10)]
    public Sprite image;
}
