using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public TMP_Text[] shopshopingredientsName;
    public Button[] shopingredientsBtns;
    public GameObject ingredientsBtn;


    public Button shoptoppingBtn;
    public Button shopBaseBtn;


    // ���� üũ�ڽ�
    public GameObject buyCheckbox;
    public Button countup;
    public Button countdown;
    public Button buy;
    public Button cancle;
    public TMP_Text buyCount;
    public TMP_Text sumMoney;
    private int buyAmount;
    private float buyprice;

    private int ingredientsNum;   // Ŭ���� ��� ����


    public GameObject shortageMoney;
    public Button nomoneyCancle;


    public List<ToppingsData> _shopToppingsData = new List<ToppingsData>();
    public List<BaseIngredientData> _shopBaseIngredientData = new List<BaseIngredientData>();


    public void Awake()
    {
        ShopToppingsDataList();
        ShopBaseIngredientList();
        ShopStartBtnsSetUp();
    }

    public void Start()
    {
        ShopBtnOnclick();
        IngredientBtnOnClick();
        BuyCheckBoxOnClick();
        
    }


    #region shoptoppingList

    public void ShopToppingsDataList()   // ���� ����Ʈ
    {
        ShopPepperoni shoppepperoni = new ShopPepperoni();
        ShopBacon shopbacon = new ShopBacon();
        ShopPotato shoppotato = new ShopPotato();
        ShopPineapple shoppineapple = new ShopPineapple();
        ShopOlive shopolive = new ShopOlive();
        ShopMushroom shopmushroom = new ShopMushroom();
        ShopPepper shoppepper = new ShopPepper();

        _shopToppingsData.Add(shoppepperoni);
        _shopToppingsData.Add(shopbacon);
        _shopToppingsData.Add(shoppotato);
        _shopToppingsData.Add(shoppineapple);
        _shopToppingsData.Add(shopolive);
        _shopToppingsData.Add(shopmushroom);
        _shopToppingsData.Add(shoppepper);
    }

    #endregion


    #region shopBaseIngredientList

    public void ShopBaseIngredientList()   // ���̽� ��� ����Ʈ
    {
        ShopDough shopdough = new ShopDough();
        ShopSauce shopsauce = new ShopSauce();
        ShopCheeses shopcheeses = new ShopCheeses();
        ShopCorn shopcorn = new ShopCorn();

        _shopBaseIngredientData.Add(shopdough);
        _shopBaseIngredientData.Add(shopsauce);
        _shopBaseIngredientData.Add(shopcheeses);
        _shopBaseIngredientData.Add(shopcorn);
    }

    #endregion


    public void ShopStartBtnsSetUp()  // ���� ����
    {
        ShopDataChecker shopdataChecker = new ShopDataChecker();

        shopingredientsBtns = new Button[_shopToppingsData.Count];
        shopshopingredientsName = new TMP_Text[_shopToppingsData.Count];

        

        for (int i = 0; i < _shopToppingsData.Count; i++)
        {
            shopingredientsBtns[i] = ingredientsBtn.GetComponentsInChildren<Button>()[i];
            shopshopingredientsName[i] = ingredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
        }

        for (int k = 0; k < _shopToppingsData.Count; k++)
        {
            shopshopingredientsName[k].text = _shopToppingsData[k].Name;
        }

        shopdataChecker.CheckNum = 0;
    }


    ///////////////////////////////////////////////////////////

    public void ShopToppingBtnsSetUp()  // ���ι�ư Ŭ�� ����
    {
        ShopDataChecker shopdataChecker = new ShopDataChecker();

        shopingredientsBtns = new Button[_shopToppingsData.Count];
        shopshopingredientsName = new TMP_Text[_shopToppingsData.Count];

        

        for (int  i = 0; i < _shopToppingsData.Count; i++)
        {
            shopingredientsBtns[i] = ingredientsBtn.GetComponentsInChildren<Button>()[i];
            shopshopingredientsName[i] = ingredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
        }


        for (int k = 0; k < _shopToppingsData.Count; k++)
        {
            shopshopingredientsName[k].text = _shopToppingsData[k].Name;
        }

        shopdataChecker.CheckNum = 0;
    }

    ///////////////////////////////////////////////////////////

    public void ShopBaseIngredientBtnsSetUp()  // ���̽���� Ŭ�� ����
    {
        ShopDataChecker shopdataChecker = new ShopDataChecker();

        shopingredientsBtns = new Button[_shopBaseIngredientData.Count];
        shopshopingredientsName = new TMP_Text[_shopToppingsData.Count];


        for (int i = 0; i < _shopToppingsData.Count; i++)
        {
            shopshopingredientsName[i] = ingredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
        }

        for (int k = 0; k < _shopToppingsData.Count; k++)
        {
            shopshopingredientsName[k].text = "";
        }

        for (int i = 0; i < _shopBaseIngredientData.Count; i++)
        {
            shopingredientsBtns[i] = ingredientsBtn.GetComponentsInChildren<Button>()[i];
            shopshopingredientsName[i] = ingredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
        }

        for (int k = 0; k < _shopBaseIngredientData.Count; k++)
        {
            shopshopingredientsName[k].text = _shopBaseIngredientData[k].Name;
        }

        shopdataChecker.CheckNum = 1;
    }

    ///////////////////////////////////////////////////////////

    public void ShopBtnOnclick()
    {
        shoptoppingBtn.onClick.AddListener(ShopToppingBtnsSetUp);
        shopBaseBtn.onClick.AddListener(ShopBaseIngredientBtnsSetUp);
    }

    ///////////////////////////////////////////////////////////

    public void IngredientBtnOnClick()
    {
        ShopDataChecker shopdataChecker = new ShopDataChecker();

        if (shopdataChecker.CheckNum == 0)
        {
            for (int i = 0; i < _shopToppingsData.Count; i++)
            {
                int idx = i;
                shopingredientsBtns[i].onClick.AddListener(() =>
                {
                    BuyCheckBoxSet(idx);
                });
            }
        }


        else if (shopdataChecker.CheckNum == 1)
        {
            for (int i = 0; i < _shopBaseIngredientData.Count; i++)
            {
                int idx = i;
                shopingredientsBtns[i].onClick.AddListener(() =>
                {
                    BuyCheckBoxSet(idx);
                });
            }
        }
    }


    ///////////////////////////////////////////////////////////

    public void BuyCheckBoxSet(int idx)
    {
        ingredientsNum = idx;
        buyCheckbox.SetActive(true);
    }

    ///////////////////////////////////////////////////////////
    public void BuyCheckBoxHide()
    {
        buyAmount = 0;
        buyprice = 0;
        buyCheckbox.SetActive(false);
    }

    ///////////////////////////////////////////////////////////
    public void BuyItem()
    {
        // if (���� �ݾ׺��� ���ٸ�)
        // {
        //     �� -= buyprice
        //     �κ��丮 �ش��� += buyAmount
        // }

        // else if (���� �ݾ׺��� ���ٸ�) 
        // {
        //   
        //   
        // }

        buyAmount = 0;
        buyprice = 0;
        buyCheckbox.SetActive(false);
    }

    public void BuyCheckBoxOnClick()   // ���� üũ�ڽ� ��Ŭ�� üũ
    {
        countup.onClick.AddListener(ShoppingBasketUp);
        countdown.onClick.AddListener(ShoppingBasketDown);
        cancle.onClick.AddListener(BuyCheckBoxHide);
        buy.onClick.AddListener(BuyItem);
    }

    public void CheckBoxTxt()
    {
        buyCount.text = buyAmount.ToString();
        sumMoney.text = buyprice.ToString();
    }


    public void ShoppingBasketUp()   // ���� ���� ���� �ٱ���
    {
        ShopDataChecker shopdataChecker = new ShopDataChecker();


        buyAmount += 1;
        if (shopdataChecker.CheckNum == 0)
            buyprice += _shopToppingsData[ingredientsNum].Price;
        else if (shopdataChecker.CheckNum == 1)
            buyprice += _shopBaseIngredientData[ingredientsNum].Price;

        CheckBoxTxt();
        Debug.Log(buyAmount);
        Debug.Log(buyprice);
    }


    public void ShoppingBasketDown()
    {
        ShopDataChecker shopdataChecker = new ShopDataChecker();


        buyAmount -= 1;
        if (shopdataChecker.CheckNum == 0)
            buyprice -= _shopToppingsData[ingredientsNum].Price;
        else if (shopdataChecker.CheckNum == 1)
            buyprice -= _shopBaseIngredientData[ingredientsNum].Price;

        CheckBoxTxt();
        Debug.Log(buyAmount);
        Debug.Log(buyprice);
    }
}
