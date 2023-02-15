using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopBoard : MonoBehaviour
{
    public Button[] baseingredientsBtns;
    public Button[] toppingBtns;
    public Button baseBtn;
    public Button toppBtn;
    public GameObject baseingredients;
    public GameObject toppings;

    public void Awake()
    {
        ListSetUp();
    }

    public void Start()
    {
        ChangeBtns();
    }

    public void ChangeBtns()
    {
        baseBtn.onClick.AddListener(ChangeBase);
        toppBtn.onClick.AddListener(ChangeTopping);
    }

    public void BtnSetup()
    {
        toppingBtns = new Button[toppings.name.Length];
        for (int i = 0; i < toppings.name.Length; i++)
        {
            toppingBtns[i] = toppings.GetComponentsInChildren<Button>()[i];
        }
    }

    public void ChangeBase()
    {
        baseingredientsBtns = new Button[baseingredients.name.Length];

        for (int i = 0; i < baseingredients.name.Length; i++)
        {
            baseingredientsBtns[i] = baseingredients.GetComponentsInChildren<Button>()[i];
        }
    }

    public void ChangeTopping()
    {
        toppingBtns = new Button[toppings.name.Length];

        for (int i = 0; i < toppings.name.Length; i++)
        {
            toppingBtns[i] = toppings.GetComponentsInChildren<Button>()[i];
        }
    }

    public void ListSetUp()
    {
        var baseingredients = IngredientManager.GetInstance().baseIngredientList;
        var toppings = IngredientManager.GetInstance().toppingList;
    }
}
