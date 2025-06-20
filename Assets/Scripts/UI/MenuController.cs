using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject settingsPanel;

    [Header("Audio settings")]
    [Space(10)]
    public AudioMixer mixer;
    public Slider soundSlider;


    public string[] levels;
    public void Play() 
    {
        if(PlayerPrefs.GetInt("PassedLevels") > 0)
            SceneManager.LoadSceneAsync(levels[PlayerPrefs.GetInt("PassedLevels") - 1]);
        else
            SceneManager.LoadSceneAsync(levels[PlayerPrefs.GetInt("PassedLevels")]);
    }

    public void NewGame() 
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(levels[PlayerPrefs.GetInt("PassedLevels")]);
    }

    public void GoToMenu() 
    {
        SceneManager.LoadSceneAsync("MainMenuScene");
    }
    public void ShowSettings() 
    {
        settingsPanel.SetActive(true);
    }

    public void SetSound() 
    {
        mixer.SetFloat("Volume", soundSlider.value);
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
