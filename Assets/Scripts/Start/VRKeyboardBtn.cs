using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;


public class VRKeyboardBtn : MonoBehaviour
{
    VRKeyboard keyboard;
    public TMP_Text[] btnText;
    XRSimpleInteractable interactable;
    [SerializeField] GameObject pressBtn;
    AudioManager audiomanager;


    void Start()
    {
        audiomanager = AudioManager.GetInstance();
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener((e) => {
            Debug.Log("AddListener");
            OnClickVRKeyBoard();
        });
        interactable.selectExited.AddListener((e) => {
            OffClickVRKeyBoard();
        });

        interactable.hoverEntered.AddListener((e) => { OnHoverKeyBoard(); });
        interactable.hoverExited.AddListener((e) => { OffHoverKeyBoard(); });

        keyboard = GetComponentInParent<VRKeyboard>();
        btnText = GetComponentsInChildren<TMP_Text>();

        // btnText도 지정해주어야 한다
        if (btnText.Length == 1)
        {
            NameToBtnText();
            GetComponentInChildren<ButtonVR>().onRelease.AddListener(delegate { keyboard.InsertChar(btnText[0].text); });
        }
    }

    public void NameToBtnText()
    {
        btnText[0].text = gameObject.name;
    }

    public void OnClickVRKeyBoard()
    {
        Vector3 vector = pressBtn.transform.localPosition;
        pressBtn.transform.localPosition = new Vector3(vector.x, vector.y - 0.01f, vector.z);
        keyboard.InsertChar(btnText[0].text);
        audiomanager.PlaySfx("Keyboard");
    }

    public void OffClickVRKeyBoard()
    {
        Vector3 vector = pressBtn.transform.localPosition;
        pressBtn.transform.localPosition = new Vector3(vector.x, vector.y + 0.01f, vector.z);
        //gameObject.transform.localPosition = new Vector3(0, 0.015f, 0);
    }

    public void OnHoverKeyBoard()
    {
        MeshRenderer meshrenderer = pressBtn.GetComponent<MeshRenderer>();
        meshrenderer.material = Resources.Load<Material>("Start/HovMaterial");

    }

    public void OffHoverKeyBoard()
    {
        MeshRenderer meshrenderer = pressBtn.GetComponent<MeshRenderer>();
        meshrenderer.material = Resources.Load<Material>("Start/RedMaterial");
    }
}
