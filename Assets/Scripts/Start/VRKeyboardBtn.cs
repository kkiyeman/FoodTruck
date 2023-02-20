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
    [SerializeField] GameObject pressBtn;
    

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener((e)=> {
            Debug.Log("AddListener"); 
            OnClickVRKeyBoard(); 
        });
        interactable.selectExited.AddListener((e) => {
            OffClickVRKeyBoard();
        });

        interactable.hoverEntered.AddListener((e) => { OnHoverKeyBoard(); });
        interactable.hoverExited.AddListener((e) => { OffHoverKeyBoard(); });

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
        Vector3 vector = pressBtn.transform.localPosition;
        pressBtn.transform.localPosition = new Vector3(vector.x, vector.y - 0.01f, vector.z);
        keyboard.InsertChar(btnText.text);
    }

    public void OffClickVRKeyBoard()
    {
        Vector3 vector = pressBtn.transform.localPosition;
        pressBtn.transform.localPosition= new Vector3(vector.x, vector.y + 0.01f, vector.z);
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
