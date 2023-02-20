using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;


public class VRKeyboardBtn : MonoBehaviour
{
    VRKeyboard keyboard;
    TextMeshProUGUI btnText;
    XRSimpleInteractable interactable;
    

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(delegate { keyboard.InsertChar(btnText.text); });
        keyboard = GetComponentInParent<VRKeyboard>();
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

    public void OnClickVRKeyBoard()
    {
        keyboard.InsertChar(btnText.text);
    }
}
