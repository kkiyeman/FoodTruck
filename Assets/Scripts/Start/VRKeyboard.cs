using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class VRKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject normalButtons;
    private bool caps;

    void Start()
    {
        caps = false;
    }

    public void InsertChar(string c)
    {
        inputField.text += c;
    }

    public void DeleteChar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    public void InsertSpace()
    {
        inputField.text += " ";
    }

    public void CapsPressed()
    {
        if (!caps)
        {
            normalButtons.SetActive(false);
            caps = true;
        }
        else
        {
            normalButtons.SetActive(true);
            caps = false;
        }
    }

}
