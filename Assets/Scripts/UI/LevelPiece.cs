using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPiece : MonoBehaviour
{
    public int LevelNumber;
    public Button button;
    public string SceneName;

    private void Start()
    {
        if (LevelNumber > PlayerPrefs.GetInt("PassedLevels") + 1)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void PlayLevel() 
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}
