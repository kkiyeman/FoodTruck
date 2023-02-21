using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrder : MonoBehaviour
{
    public Text txtOrder1st;
    public Text txtOrder2nd;
    public Button[] btnUIOrder;

    public void SetOrder(string pizzaName, int cnt)
    {
        txtOrder1st.text = $"{pizzaName} {cnt}ÆÇ";
    }

    public void SetOrder2nd(string pizzaName, int cnt)
    {

    }
    public Text OrderTxt()
    {
        return txtOrder1st;
    }
}
