using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingGroup : MonoBehaviour
{
    public Vector3 direction;

    public GameObject[] gameObjects;
    CameraWallsChecker checker;

    bool isShown;

    public float value;

    private void Start()
    {
        checker = CameraWallsChecker.instance;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, direction.normalized * 0.2f);
        Gizmos.DrawSphere(transform.position, 0.05f);
    }

    private void Update()
    {
        value = Vector3.Dot(checker.direction, direction);

        if (value > 0.75f && isShown)
        {
            HideAll();
        }
        else if(value < 0.75f && !isShown)
        {
            ShowAll();
        }
    }

    void HideAll() 
    {
        foreach(GameObject go in gameObjects) 
        {
            go.SetActive(false);
        }

        isShown = false;
    }

    void ShowAll() 
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(true);
        }

        isShown = true;
    }
}
