using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public delegate void OnInteract(IInteractable.eventData SenderInteractionConfig);

    /// Accesible event with args for custom interactive object's scenarios
    public OnInteract Interaction;

    [Space(10)]
    public bool NeedsPlayerToFocus = false;
    

    [HideInInspector]
    public bool InvokeDelegate = false;
    [Space(10)]
    public UnityEvent OnInteraction;


    public IInteractable.eventData ReceiverInteractionConfig;


    public void Interact(IInteractable.eventData SenderConfig)
    {
        if (NeedsPlayerToFocus && PlayerController.Instance.state != PlayerController.State.Focused) 
        {
            Debug.Log("Player needs to be focused on this object" + gameObject.name);
            return;
        }
        if (ReceiverInteractionConfig.useWithItem)
        {
            if (SenderConfig.inventoryItem == null) 
            {
                Debug.Log("No item selected");
                return;
            }

            if (ReceiverInteractionConfig.inventoryItem == SenderConfig.inventoryItem)
            {
                InvokeEvents(SenderConfig);

                if (ReceiverInteractionConfig.destroyItemAfterUse) 
                {
                    SenderConfig.inventoryBase.Remove(SenderConfig.inventoryItem);
                }
            }
            else
            {
                Debug.Log("Wrong Item: " + SenderConfig.inventoryItem.itemId);
            }
        }
        else 
        {
            InvokeEvents(SenderConfig);
        }
    }

    void InvokeEvents(IInteractable.eventData SenderInteractionConfig) 
    {
        if(InvokeDelegate)
            Interaction.Invoke(SenderInteractionConfig);

        OnInteraction.Invoke();
    }
}
