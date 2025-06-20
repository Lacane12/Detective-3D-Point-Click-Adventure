using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_item : MonoBehaviour, IPointerClickHandler
{
    public Image image;

    public Color highlightedColor;
    public inventoryItem itemReference;

    public delegate void Selected(UI_item item);
    public Selected wasSelected;
    public Selected wasDeselected;
    //Selected/Unselected event

    bool isSelected;
    int InventoryIndex;
    
    Color originColor;

    public void SetItem(inventoryItem item, int index) 
    {
        itemReference = item;
        SetImage(itemReference.image);
        InventoryIndex = index;
    }

    void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
        originColor = image.color;
    }

    public void Select() 
    {
        image.color = highlightedColor;
        Debug.Log("Selected");
    }

    public void Deselect() 
    {
        image.color = originColor;
        Debug.Log("Deselected");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSelected) 
        {
            Deselect();
            wasDeselected.Invoke(this);
        }
        else 
        {
            Select();
            wasSelected.Invoke(this);
        }

        isSelected = !isSelected;

    }

    //TODO UI INTERACTION WITH ITEMS
}
