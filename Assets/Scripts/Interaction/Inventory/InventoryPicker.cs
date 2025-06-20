using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class InventoryPicker : MonoBehaviour
{
    public inventoryItem item;

    InteractableObject obj;

    private void Start()
    {
        obj = GetComponent<InteractableObject>();
        obj.InvokeDelegate = true;

        obj.Interaction += PickUp;
        
    }

    public void PickUp(IInteractable.eventData SenderConfig) 
    {
        SenderConfig.inventoryBase.Add(item);
        Destroy(gameObject);
    }
}
