using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class KeyboardBtn : MonoBehaviour
{
    Keyboard keyboard;
    TextMeshProUGUI btnText;

    void Start()
    {
        keyboard = GetComponentInParent<Keyboard>();
        btnText = GetComponentInChildren<TextMeshProUGUI>();

        if (btnText.text.Length == 1)
        {
            NameToBtnText();
            GetComponentInChildren<ButtonVR>().onRelease.AddListener(delegate { keyboard.InsertChar(btnText.text); });
        }
    }

    public void NameToBtnText()
    {
        btnText.text = gameObject.name;
    }
}
