using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Transform cameraPivot;

    public GameObject[] frontWalls;
    public GameObject[] leftWalls;
    public GameObject[] rightWalls;
    public GameObject[] backWalls;

    public void Update()
    {
        CheckWalls();
    }

    public void CheckWalls() 
    {
        if (cameraPivot.rotation.eulerAngles.y == 0)
            HideWalls(frontWalls);
        else if (cameraPivot.rotation.eulerAngles.y <= -90)
            HideWalls(leftWalls);
        else if (cameraPivot.rotation.eulerAngles.y >= 90)
            HideWalls(rightWalls);


    }

    void ShowAllWalls() 
    {
        foreach (GameObject wall in frontWalls) 
        {
            wall.SetActive(true);
        }
        foreach (GameObject wall in leftWalls)
        {
            wall.SetActive(true);
        }
        foreach (GameObject wall in rightWalls)
        {
            wall.SetActive(true);
        }
        foreach (GameObject wall in backWalls)
        {
            wall.SetActive(true);
        }
    }

    void HideWalls(GameObject[] walls) 
    {
        ShowAllWalls();

        foreach (GameObject wall in walls) 
        {
            wall.SetActive(false);
        }
    }
}
