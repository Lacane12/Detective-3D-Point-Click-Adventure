using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int CurrentLevelNumber = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void LoadScene(string sceneName) 
    {
        CompleteLevel();

        SceneManager.LoadScene(sceneName);
    }

    void CompleteLevel() 
    {
        if (CurrentLevelNumber > PlayerPrefs.GetInt("PassedLevels")) 
        {
            PlayerPrefs.SetInt("PassedLevels", CurrentLevelNumber);
            PlayerPrefs.SetString("LastLevelName", SceneManager.GetActiveScene().name);
        }
    }
}
