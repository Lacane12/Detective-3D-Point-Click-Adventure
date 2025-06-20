using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CodeLock : MonoBehaviour
{
    public string PassCode;
    public string CurrentCode;
    [Space(10)]
    public TextMeshProUGUI codeText;
    [Space(10)]
    public UnityEvent Unlock;

    private void Start()
    {
        UpdateCodeText();
    }
    public void CheckCode() 
    {
        if (CurrentCode == PassCode) 
        {
            Debug.Log("Right Code!");
            Unlock.Invoke();
        }
        else 
        {
            ClearCurrentCode();
        }
    }

    public void AddNumber(int number) 
    {
        if (CurrentCode.Length >= PassCode.Length)
            return;

        CurrentCode += number.ToString();

        UpdateCodeText();
    }

    public void ClearCurrentCode() 
    {
        CurrentCode = "";

        UpdateCodeText();
    }

    void UpdateCodeText() 
    {
        codeText.text = CurrentCode;
    }
    
}
