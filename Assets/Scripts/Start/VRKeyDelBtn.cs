using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class VRKeyDelBtn : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject normalButtons;

    public void DeleteChar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

}
