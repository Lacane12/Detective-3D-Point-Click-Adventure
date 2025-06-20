using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelAnnouncer : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public Animator textAnim;
    public string Text;

    private void Start()
    {
        Announce();
    }
    void Announce() 
    {
        textUI.text = Text;
        textAnim.SetTrigger("Show");
    }
}
