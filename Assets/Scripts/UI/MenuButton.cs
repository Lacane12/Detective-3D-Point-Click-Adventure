using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void Focus() 
    {
        PlayerController.Instance.state = PlayerController.State.Focused;
    }

    public void Unfocus() 
    {
        PlayerController.Instance.state = PlayerController.State.Global;
    }
}
