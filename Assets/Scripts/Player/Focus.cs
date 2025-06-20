using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class Focus : MonoBehaviour
{
    public Camera focusedCamera;

    private void Start()
    {
        focusedCamera.enabled = false;

        InteractableObject obj = GetComponent<InteractableObject>();
        obj.OnInteraction.AddListener(FocusPlayer);
    }
    public void FocusPlayer() 
    {
        focusedCamera.enabled = true;
        PlayerController.Instance.FocusPlayer(focusedCamera);
    }


}
