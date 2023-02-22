using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;


    private TMP_Text[] inveningredientsName;
    private Button[] inveningredientsBtns;
    public GameObject inveningredientsBtn;

    public GameObject invenTImage;
    public Image[] invenToppImages;

    private TMP_Text[] inveningredientCounttxts;
    public GameObject inveningredientCounttxtG;

    public TMP_Text myMoney;   // 내 자산


    public Button inventoppingBtn;
    public Button invenBaseBtn;

    public Button invenExit;

    //PlayerData playerData = new PlayerData();
    public GameObject shop;


    public void Awake()
    {
        InvenStartUISetUp();
        InventoryFalse();
    }


    public void Start()
    {
        InvenBtnOnclick();
    }



    public void InvenStartUISetUp()  // 시작전 UI 세팅
    {
        inveningredientsBtns = new Button[inveningredientsBtn.GetComponentsInChildren<Button>().Length];
        inveningredientsName = new TMP_Text[inveningredientsBtn.GetComponentsInChildren<Button>().Length];
        inveningredientCounttxts = new TMP_Text[inveningredientCounttxtG.GetComponentsInChildren<TMP_Text>().Length];
        invenToppImages = new Image[invenTImage.GetComponentsInChildren<Image>().Length];

        for (int i = 0; i < inveningredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            inveningredientsBtns[i] = inveningredientsBtn.GetComponentsInChildren<Button>()[i];
            inveningredientsName[i] = inveningredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
            inveningredientCounttxts[i] = inveningredientCounttxtG.GetComponentsInChildren<TMP_Text>()[i];
            invenToppImages[i] = invenTImage.GetComponentsInChildren<Image>()[i];
            inveningredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        Debug.Log(GameManager.GetInstance()._ToppingInvenAcount[3]);

        for (int i = 0; i < 8; i++)
            invenToppImages[i].gameObject.SetActive(false);

        for (int i = 0; i < shop.GetComponent<Shop>()._ToppingsData.Count; i++)
            invenToppImages[i].gameObject.SetActive(true);


        for (int i = 0; i < GameManager.GetInstance()._ToppingInvenAcount.Count; i++)
        {
            shop.GetComponent<Shop>()._ToppingsData[i].InvenAmount = GameManager.GetInstance()._ToppingInvenAcount[i];
        }

        for (int i = 0; i < GameManager.GetInstance()._BaseInvenAcount.Count; i++)
        {
            shop.GetComponent<Shop>()._BaseIngredientData[i].InvenAmount = GameManager.GetInstance()._BaseInvenAcount[i];
        }

        for (int k = 0; k < shop.GetComponent<Shop>()._ToppingsData.Count; k++)
        {
            inveningredientsName[k].text = shop.GetComponent<Shop>()._ToppingsData[k].Name;
            inveningredientCounttxts[k].text = shop.GetComponent<Shop>()._ToppingsData[k].InvenAmount.ToString();
            invenToppImages[k].sprite = Resources.Load<Sprite>($"Image/{shop.GetComponent<Shop>()._ToppingsData[k].Name}");
            inveningredientsBtns[k].GetComponent<Button>().interactable = true;
        }
        InvenMyMoneySetUp();
    }

    public void InvenMyMoneySetUp()
    {
        myMoney.text = shop.GetComponent<Shop>().playerData.money.ToString();
    }

    public void InvenToppingBtnsSetUp()  // 토핑버튼 클릭 세팅
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
        for (int i = 0; i < inveningredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            inveningredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < 8; i++)
            invenToppImages[i].gameObject.SetActive(false);

        for (int i = 0; i < shop.GetComponent<Shop>()._ToppingsData.Count; i++)
            invenToppImages[i].gameObject.SetActive(true);

        for (int k = 0; k < shop.GetComponent<Shop>()._ToppingsData.Count; k++)
        {
            inveningredientsName[k].text = shop.GetComponent<Shop>()._ToppingsData[k].Name;
            inveningredientCounttxts[k].text = shop.GetComponent<Shop>()._ToppingsData[k].InvenAmount.ToString();
            invenToppImages[k].sprite = Resources.Load<Sprite>($"Image/{shop.GetComponent<Shop>()._ToppingsData[k].Name}");
            inveningredientsBtns[k].GetComponent<Button>().interactable = true;
        }
    }

    ///////////////////////////////////////////////////////////

    public void InvenBaseIngredientBtnsSetUp()  // 베이스재료 클릭 세팅
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
        for (int i = 0; i < shop.GetComponent<Shop>()._ToppingsData.Count; i++)
        {
            inveningredientCounttxts[i].text = "";
            inveningredientsName[i].text = "";
        }

        for (int i = 0; i < 8; i++)
            invenToppImages[i].gameObject.SetActive(false);

        for (int i = 0; i < shop.GetComponent<Shop>()._BaseIngredientData.Count; i++)
            invenToppImages[i].gameObject.SetActive(true);

        for (int i = 0; i < inveningredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            inveningredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        

        for (int k = 0; k < shop.GetComponent<Shop>()._BaseIngredientData.Count; k++)
        {
            inveningredientsName[k].text = shop.GetComponent<Shop>()._BaseIngredientData[k].Name;
            inveningredientCounttxts[k].text = shop.GetComponent<Shop>()._BaseIngredientData[k].InvenAmount.ToString();
            Debug.Log(shop.GetComponent<Shop>()._BaseIngredientData[k].InvenAmount);
            invenToppImages[k].sprite = Resources.Load<Sprite>($"Image/{shop.GetComponent<Shop>()._BaseIngredientData[k].Name}");
            inveningredientsBtns[k].GetComponent<Button>().interactable = true;
        }
    }

    public void BuyInvenBaseCountReset(int idx)
    {
        inveningredientCounttxts[idx].text = shop.GetComponent<Shop>()._BaseIngredientData[idx].InvenAmount.ToString();
        //InvenMyMoneySetUp();
    }

    public void BuyInvenToppingCountReset(int idx)
    {
        inveningredientCounttxts[idx].text = shop.GetComponent<Shop>()._ToppingsData[idx].InvenAmount.ToString();
        //InvenMyMoneySetUp();
    }

    public void InventoryFalse()   // 인벤토리 창 끄기
    {
        AudioManager.GetInstance().PlaySfx("Click");
        inventory.SetActive(false);
    }

    public void InvenBtnOnclick()   // 
    {
        inventoppingBtn.onClick.AddListener(InvenToppingBtnsSetUp);
        invenBaseBtn.onClick.AddListener(InvenBaseIngredientBtnsSetUp);
        invenExit.onClick.AddListener(InventoryFalse);
    }

}
