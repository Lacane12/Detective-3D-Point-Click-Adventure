using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBase : MonoBehaviour
{
    public List<inventoryItem> inventoryItems = new List<inventoryItem>();
    public List<UI_item> UIitems = new List<UI_item>();
    [Space(10)]


    [Header("UI Config")]

    public GameObject inventoryScroll;
    public GameObject inventoryItemPrefab;

    public InteractionBase interactionBase;

    private void Start()
    {
        UpdateUI();
    }
    public void Add(inventoryItem item) 
    {
        inventoryItems.Add(item);

        UpdateUI();
    }

    public void Remove(inventoryItem item) 
    {
        if(item != null) 
        {
            inventoryItems.Remove(item);
        }

        UpdateUI();
    }

    void ConnectUIItemsToBase(List<UI_item> UIitems)
    {
        foreach (var item in UIitems)
        {
            item.wasSelected += SelectItem;
            item.wasDeselected += DeselectItem;
        }
    }

    void SelectItem(UI_item UIitem) 
    {
        DeselectOthers();

        interactionBase.interactionConfig.useWithItem = true;
        interactionBase.interactionConfig.inventoryItem = UIitem.itemReference;

        UIitem.Select();
    }

    void DeselectOthers() 
    {
        foreach (var item in UIitems) 
        {
            DeselectItem(item);
        }
    }

    void DeselectItem(UI_item UIitem) 
    {
        interactionBase.interactionConfig.useWithItem = false;
        interactionBase.interactionConfig.inventoryItem = null;
        UIitem.Deselect();
    }

    void UpdateUI() 
    {
        ClearScroll();

        UpdateScroll();

        ConnectUIItemsToBase(UIitems);
    }

    void ClearScroll() 
    {
        for (int i = 0; i < inventoryScroll.transform.childCount; i++)
        {
            var child = inventoryScroll.transform.GetChild(i);
            Destroy(child.gameObject);
            UIitems.Clear();
        }
    }

    void UpdateScroll() 
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            newItemUI(inventoryItems[i], i);
        }
    }

    GameObject newItemUI(inventoryItem item, int index) 
    {
        GameObject result;

        result = Instantiate(inventoryItemPrefab, inventoryScroll.transform);

        var UiItem = result.GetComponent<UI_item>();

        UiItem.SetItem(item, index);

        //Adding ui items to ui inventory

        UIitems.Add(UiItem);

        return result;
    }

    

}
