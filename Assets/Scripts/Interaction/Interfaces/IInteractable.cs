using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    [Serializable]
    public class eventData 
    {
        public bool useWithItem = false;
        public bool destroyItemAfterUse = false;
        [Space(5)]
        public inventoryItem inventoryItem;
        [Space(5)]
        public InventoryBase inventoryBase;
    }

    public void Interact(eventData data);

}
