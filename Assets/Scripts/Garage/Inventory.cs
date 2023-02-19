using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;


    public TMP_Text[] inveningredientsName;
    public Button[] inveningredientsBtns;
    public GameObject inveningredientsBtn;

    public TMP_Text[] inveningredientCounttxts;
    public GameObject inveningredientCounttxtG;

    public TMP_Text myMoney;   // 내 자산


    public Button inventoppingBtn;
    public Button invenBaseBtn;

    public Button invenExit;

    PlayerData playerData = new PlayerData();
    public GameObject shop;

    //public List<ToppingsData> _ToppingsData = new List<ToppingsData>();
    //public List<BaseIngredientData> _BaseIngredientData = new List<BaseIngredientData>();


    public void Awake()
    {
        //shop.ToppingsDataList();
        //shop.BaseIngredientList();
        InvenStartUISetUp();
        InventoryFalse();
    }


    public void Start()
    {
        InvenBtnOnclick();
        
    }


    #region inventoppingList

    //public void InvenToppingsDataList()   // 토핑 리스트
    //{
    //    Pepperoni pepperoni = new Pepperoni();
    //    Bacon bacon = new Bacon();
    //    Potato potato = new Potato();
    //    Pineapple pineapple = new Pineapple();
    //    Olive olive = new Olive();
    //    Mushroom mushroom = new Mushroom();
    //    Pepper pepper = new Pepper();
    //
    //    _ToppingsData.Add(pepperoni);
    //    _ToppingsData.Add(bacon);
    //    _ToppingsData.Add(potato);
    //    _ToppingsData.Add(pineapple);
    //    _ToppingsData.Add(olive);
    //    _ToppingsData.Add(mushroom);
    //    _ToppingsData.Add(pepper);
    //}

    #endregion


    #region invenBaseIngredientList

    //public void InvenBaseIngredientList()   // 베이스 재료 리스트
    //{
    //    Dow dow = new Dow();
    //    Sauce sauce = new Sauce();
    //    Cheese cheese = new Cheese();
    //    Corn corn = new Corn();
    //
    //    _BaseIngredientData.Add(dow);
    //    _BaseIngredientData.Add(sauce);
    //    _BaseIngredientData.Add(cheese);
    //    _BaseIngredientData.Add(corn);
    //}

    #endregion



    public void InvenSetActive()
    {
        if (inventory.gameObject.activeSelf == true)
             InvenStartUISetUp();
    }

    public void InvenStartUISetUp()  // 시작전 UI 세팅
    {
        inveningredientsBtns = new Button[inveningredientsBtn.GetComponentsInChildren<Button>().Length];
        inveningredientsName = new TMP_Text[inveningredientsBtn.GetComponentsInChildren<Button>().Length];
        inveningredientCounttxts = new TMP_Text[inveningredientCounttxtG.GetComponentsInChildren<TMP_Text>().Length];

        for (int i = 0; i < inveningredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            inveningredientsBtns[i] = inveningredientsBtn.GetComponentsInChildren<Button>()[i];
            inveningredientsName[i] = inveningredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
            inveningredientCounttxts[i] = inveningredientCounttxtG.GetComponentsInChildren<TMP_Text>()[i];
            inveningredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        for (int k = 0; k < shop.GetComponent<Shop>()._ToppingsData.Count; k++)
        {
            inveningredientsName[k].text = shop.GetComponent<Shop>()._ToppingsData[k].Name;
            inveningredientCounttxts[k].text = shop.GetComponent<Shop>()._ToppingsData[k].InvenAmount.ToString();
            inveningredientsBtns[k].GetComponent<Button>().interactable = true;
        }
        InvenMyMoneySetUp();
    }

    public void InvenMyMoneySetUp()
    {
        //myMoney.text = playerData.money.ToString();
    }


    public void InvenToppingBtnsSetUp()  // 토핑버튼 클릭 세팅
    {
        //inveningredientsBtns = new Button[inveningredientsBtn.GetComponentsInChildren<Button>().Length];
        //inveningredientsName = new TMP_Text[inveningredientsBtn.GetComponentsInChildren<Button>().Length];

        for (int i = 0; i < inveningredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            //inveningredientsBtns[i] = inveningredientsBtn.GetComponentsInChildren<Button>()[i];
            //inveningredientsName[i] = inveningredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
            inveningredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        for (int k = 0; k < shop.GetComponent<Shop>()._ToppingsData.Count; k++)
        {
            inveningredientsName[k].text = shop.GetComponent<Shop>()._ToppingsData[k].Name;
            inveningredientCounttxts[k].text = shop.GetComponent<Shop>()._ToppingsData[k].InvenAmount.ToString();
            inveningredientsBtns[k].GetComponent<Button>().interactable = true;
        }
    }

    ///////////////////////////////////////////////////////////

    public void InvenBaseIngredientBtnsSetUp()  // 베이스재료 클릭 세팅
    {
        //inveningredientsBtns = new Button[inveningredientsBtn.GetComponentsInChildren<Button>().Length];
        //inveningredientsName = new TMP_Text[inveningredientsBtn.GetComponentsInChildren<Button>().Length];

        for (int i = 0; i < shop.GetComponent<Shop>()._ToppingsData.Count; i++)
        {
            //inveningredientsName[i] = inveningredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
            inveningredientCounttxts[i].text = "";
            inveningredientsName[i].text = "";
        }

        for (int i = 0; i < inveningredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            //inveningredientsBtns[i] = inveningredientsBtn.GetComponentsInChildren<Button>()[i];
            //inveningredientsName[i] = inveningredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
            inveningredientsBtns[i].GetComponent<Button>().interactable = false;
        }


        for (int k = 0; k < shop.GetComponent<Shop>()._BaseIngredientData.Count; k++)
        {
            inveningredientsName[k].text = shop.GetComponent<Shop>()._BaseIngredientData[k].Name;
            inveningredientCounttxts[k].text = shop.GetComponent<Shop>()._BaseIngredientData[k].InvenAmount.ToString();
            Debug.Log(shop.GetComponent<Shop>()._BaseIngredientData[k].InvenAmount);
            inveningredientsBtns[k].GetComponent<Button>().interactable = true;
        }
    }

    public void BuyInvenBaseCountReset(int idx)
    {
        //for (int k = 0; k < _BaseIngredientData.Count; k++)
        //{
        inveningredientCounttxts[idx].text = shop.GetComponent<Shop>()._BaseIngredientData[idx].InvenAmount.ToString();
        //}
    }

    public void BuyInvenToppingCountReset(int idx)
    {
        //for (int k = 0; k < _ToppingsData.Count; k++)
        //{
        inveningredientCounttxts[idx].text = shop.GetComponent<Shop>()._ToppingsData[idx].InvenAmount.ToString();
        //}
    }


    public void InventoryFalse()   // 인벤토리 창 끄기
    {
        inventory.SetActive(false);
    }


    public void InvenBtnOnclick()   // 
    {
        inventoppingBtn.onClick.AddListener(InvenToppingBtnsSetUp);
        invenBaseBtn.onClick.AddListener(InvenBaseIngredientBtnsSetUp);
        invenExit.onClick.AddListener(InventoryFalse);
    }

}
