using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject button;
    PlayerController controller;

    bool isShown = false;

    private void Start()
    {
        controller = PlayerController.Instance;
    }
    private void Update()
    {
        if (controller.state == PlayerController.State.Focused && !isShown) 
        {
            isShown = true;
            button.SetActive(true);
        }

        if (controller.state == PlayerController.State.Global && isShown) 
        {
            isShown = false;
            button.SetActive(false);
        }
    }
    public void GoBack() 
    {
        controller.UnfocusPlayer();
    }
}
