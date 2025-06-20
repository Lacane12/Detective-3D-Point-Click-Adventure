using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsHider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        Debug.Log(other.gameObject.name + " is hidden!");
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(true);

        Debug.Log(other.gameObject.name + " is shown" +
            "!");
    }
}
