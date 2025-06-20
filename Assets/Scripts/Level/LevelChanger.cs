using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public string LevelName;
    public void ChangeLevel() 
    {
        LevelSequenceController.instance.ChangeRoom(LevelName);
    }
}
