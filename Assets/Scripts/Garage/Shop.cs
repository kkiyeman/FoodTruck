using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public Button inventoryOpen;
    public GameObject inventoryS;

    private TMP_Text[] shopingredientsName;
    private Button[] shopingredientsBtns;
    public GameObject TImages;
    public Image[] shopingredientsImgs;
    public GameObject ingredientsBtn;

    private TMP_Text[] shopingredientCounttxts;
    public GameObject shopingredientCounttxtG;

    private Image[] saleImage;
    public GameObject saleImagesG;

    public TMP_Text myMoney;   // 내 자산

    public Button shoptoppingBtn;
    public Button shopBaseBtn;


    // 구매 체크박스
    public GameObject buyCheckbox;
    public Button countup;
    public Button countdown;
    public Button buy;
    public Button cancle;
    public TMP_Text buyCount;
    public TMP_Text sumMoney;


    private float fPercent = 20.0f;
    private float[] _shopToppingPrice;   // 토핑 가격
    private float[] _shopBasePrice;   // 기본재료 가격
    private int buyAmount;   // 구매 체크박스 개수
    private float buyprice;   // 구매 체크박스 가격

    private int ingredientsNum;   // 클릭된 재료 저장
    public int saleToppingNum;   // 세일 토핑 번호
    public int saleBaseNum;   // 세일 기본재료 번호


    // 구매 자산 부족 체크박스
    public GameObject shortageMoney;
    public Button nomoneyCancle;

    ShopDataChecker shopdataChecker = new ShopDataChecker();
    public PlayerData playerData = new PlayerData();
    public DataManager dataManager;


    public GameObject inventory;
    public GameObject mainbaord;

    /// //////////////////////////////////////////////////////////////////////////////////

    public List<ToppingsData> _ToppingsData = new List<ToppingsData>();
    public List<ToppingsData> _BaseIngredientData = new List<ToppingsData>();

    //////////////////////////////////////////////////////////////////////////////////////

    public void Awake()
    {
        ToppingsDataList();
        BaseIngredientList();
        ShopIngredientsSetUp();
        ShopStartUISetUp();
    }

    public void Start()
    {
        ShopBtnOnclick();
        IngredientBtnOnClick();
        BuyCheckBoxOnClick();
    }

    #region shoptoppingList

    public void ToppingsDataList()   // 토핑 리스트
    {
        Pepperoni pepperoni = new Pepperoni();
        Bacon bacon = new Bacon();
        Potato potato = new Potato();
        Pineapple pineapple = new Pineapple();
        Olive olive = new Olive();
        Mushroom mushroom = new Mushroom();
        Pepper pepper = new Pepper();

        _ToppingsData.Add(pepperoni);
        _ToppingsData.Add(bacon);
        _ToppingsData.Add(potato);
        _ToppingsData.Add(pineapple);
        _ToppingsData.Add(olive);
        _ToppingsData.Add(mushroom);
        _ToppingsData.Add(pepper);
    }

    #endregion

    #region shopBaseIngredientList

    public void BaseIngredientList()   // 베이스 재료 리스트
    {
        Dow dow = new Dow();
        Sauce sauce = new Sauce();
        Cheese cheese = new Cheese();
        Corn corn = new Corn();

        _BaseIngredientData.Add(dow);
        _BaseIngredientData.Add(sauce);
        _BaseIngredientData.Add(cheese);
        _BaseIngredientData.Add(corn);
    }

    #endregion



    public void ShopIngredientsSetUp()   // 시작전 기본값 세팅
    {
        saleToppingNum = Random.Range(0, _ToppingsData.Count);
        saleBaseNum = Random.Range(0, _BaseIngredientData.Count);
        _shopToppingPrice = new float[_ToppingsData.Count];
        _shopBasePrice = new float[_BaseIngredientData.Count];

        for (int i = 0; i < _ToppingsData.Count; i++)
        {
            _ToppingsData[i].ShopAmount = Random.Range(6, 10);
            _shopToppingPrice[i] = _ToppingsData[i].Price;
        }

        for (int i = 0; i < _BaseIngredientData.Count; i++)
        {
            _BaseIngredientData[i].ShopAmount = Random.Range(11, 15);
            _shopBasePrice[i] = _BaseIngredientData[i].Price;
        }

        _shopToppingPrice[saleToppingNum] *= (1 - fPercent / 100);
        _shopBasePrice[saleBaseNum] *= (1 - fPercent / 100);
        ShopMyMoneySetUp();

        mainbaord.GetComponent<MainBoard>().sale_1.text = _ToppingsData[saleToppingNum].Name + " -20%";
        mainbaord.GetComponent<MainBoard>().sale_2.text = _BaseIngredientData[saleBaseNum].Name + " -20%";

        for (int i = 0; i < _ToppingsData.Count; i++)
        {
            _ToppingsData[i].InvenAmount = GameManager.GetInstance()._ToppingInvenAcount[i];
        }

        for (int i = 0; i < _BaseIngredientData.Count; i++)
        {
            _BaseIngredientData[i].InvenAmount = GameManager.GetInstance()._BaseInvenAcount[i];
        }
    }

    public void ShopStartUISetUp()  // 시작전 UI 세팅
    {
        shopingredientsBtns = new Button[ingredientsBtn.GetComponentsInChildren<Button>().Length];
        shopingredientsName = new TMP_Text[ingredientsBtn.GetComponentsInChildren<Button>().Length];
        saleImage = new Image[saleImagesG.GetComponentsInChildren<Image>().Length];
        shopingredientCounttxts = new TMP_Text[shopingredientCounttxtG.GetComponentsInChildren<TMP_Text>().Length];
        shopingredientsImgs = new Image[TImages.GetComponentsInChildren<Image>().Length];


        for (int i = 0; i < ingredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            shopingredientsBtns[i] = ingredientsBtn.GetComponentsInChildren<Button>()[i];
            shopingredientsName[i] = ingredientsBtn.GetComponentsInChildren<TMP_Text>()[i];
            saleImage[i] = saleImagesG.GetComponentsInChildren<Image>()[i];
            shopingredientCounttxts[i] = shopingredientCounttxtG.GetComponentsInChildren<TMP_Text>()[i];
            shopingredientsImgs[i] = TImages.GetComponentsInChildren<Image>()[i];
            
            shopingredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < ingredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            shopingredientsImgs[i].gameObject.SetActive(false);
        }
        
        for (int i = 0; i < _ToppingsData.Count; i++)
        {
            shopingredientsImgs[i].gameObject.SetActive(true);
        }

        for (int k = 0; k < _ToppingsData.Count; k++)
        {
            shopingredientsName[k].text = _ToppingsData[k].Name;
            shopingredientCounttxts[k].text = _ToppingsData[k].ShopAmount.ToString();
            shopingredientsBtns[k].GetComponent<Button>().interactable = true;

            shopingredientsImgs[k].sprite = Resources.Load<Sprite>($"Image/{_ToppingsData[k].Name}");
        }

        for (int i = 0; i < 8; i++)
        {
            saleImage[i].gameObject.SetActive(false);
        }

        saleImage[saleToppingNum].gameObject.SetActive(true);

        shopdataChecker.CheckNum = 0;

        // Debug.Log(inventory.me);
    }


    ///////////////////////////////////////////////////////////

    public void ShopToppingBtnsSetUp()  // 토핑버튼 클릭 세팅
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
        for (int i = 0; i < ingredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            shopingredientsBtns[i].GetComponent<Button>().interactable = false;
        }

        for (int i = 0; i < ingredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            shopingredientsImgs[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _ToppingsData.Count; i++)
        {
            shopingredientsImgs[i].gameObject.SetActive(true);
        }


        for (int k = 0; k < _ToppingsData.Count; k++)
        {
            shopingredientsName[k].text = _ToppingsData[k].Name;
            shopingredientCounttxts[k].text = _ToppingsData[k].ShopAmount.ToString();
            shopingredientsBtns[k].GetComponent<Button>().interactable = true;
            shopingredientsImgs[k].sprite = Resources.Load<Sprite>($"Image/{_ToppingsData[k].Name}");
        }

        

        saleImage[saleBaseNum].gameObject.SetActive(false);
        saleImage[saleToppingNum].gameObject.SetActive(true);

        shopdataChecker.CheckNum = 0;

    }

    ///////////////////////////////////////////////////////////

    public void ShopBaseIngredientBtnsSetUp()  // 베이스재료 클릭 세팅
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
        for (int i = 0; i < _ToppingsData.Count; i++)
        {
            shopingredientCounttxts[i].text = "";
            shopingredientsName[i].text = "";
        }

        for (int i = 0; i < ingredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            shopingredientsBtns[i].GetComponent<Button>().interactable = false;
            shopingredientsImgs[i].sprite = null;
        }

        for (int i = 0; i < ingredientsBtn.GetComponentsInChildren<Button>().Length; i++)
        {
            shopingredientsImgs[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < _BaseIngredientData.Count; i++)
        {
            shopingredientsImgs[i].gameObject.SetActive(true);
        }


        for (int k = 0; k < _BaseIngredientData.Count; k++)
        {
            shopingredientsName[k].text = _BaseIngredientData[k].Name;
            shopingredientCounttxts[k].text = _BaseIngredientData[k].ShopAmount.ToString();
            shopingredientsImgs[k].sprite = Resources.Load<Sprite>($"Image/{_BaseIngredientData[k].Name}");
            shopingredientsBtns[k].GetComponent<Button>().interactable = true;
        }


        saleImage[saleToppingNum].gameObject.SetActive(false);
        saleImage[saleBaseNum].gameObject.SetActive(true);

        shopdataChecker.CheckNum = 1;
    }

    ///////////////////////////////////////////////////////////

    public void ShopBtnOnclick()   // 버튼클릭 모음
    {
        shoptoppingBtn.onClick.AddListener(ShopToppingBtnsSetUp);
        shopBaseBtn.onClick.AddListener(ShopBaseIngredientBtnsSetUp);
        inventoryOpen.onClick.AddListener(InventoryOpen);
    }

    ///////////////////////////////////////////////////////////


    public void InventoryOpen()   // 인벤토리 오픈
    {
        AudioManager.GetInstance().PlaySfx("Click");
        inventoryS.SetActive(true);
        inventoryS.GetComponent<Inventory>().InvenMyMoneySetUp();
        //inventoryS.GetComponent<Inventory>().InvenStartUISetUp();
    }

    public void IngredientBtnOnClick()   // 재료 개인버튼 클릭
    {
        if (shopdataChecker.CheckNum == 0)
        {
            for (int i = 0; i < _ToppingsData.Count; i++)
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
            for (int i = 0; i < _BaseIngredientData.Count; i++)
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

    public void BuyCheckBoxSet(int idx)  // 구매 체크박스 켜기
    {
        ingredientsNum = idx;
        buyCheckbox.SetActive(true);
        AudioManager.GetInstance().PlaySfx("Click");
    }

    ///////////////////////////////////////////////////////////
    public void BuyCheckBoxHide()  // 체크박스 닫힐때 세팅
    {
        AudioManager.GetInstance().PlaySfx("Click");
        buyAmount = 0;
        buyprice = 0.00f;
        CheckBoxTxt();
        buyCheckbox.SetActive(false);
    }

    ///////////////////////////////////////////////////////////
    public void BuyItem()  // 아이템 구매시 적용
    {       // playerData.money >= buyprice && 
        if (playerData.money >= buyprice && shopdataChecker.CheckNum == 0)
        {
            playerData.money -= buyprice;
            _ToppingsData[ingredientsNum].ShopAmount -= buyAmount;
            _ToppingsData[ingredientsNum].InvenAmount += buyAmount;
            BuyToppingCountReset();
            inventory.GetComponent<Inventory>().BuyInvenToppingCountReset(ingredientsNum);
            mainbaord.GetComponent<MainBoard>().money.text = playerData.money.ToString();
            GameManager.GetInstance()._ToppingInvenAcount[ingredientsNum] = _ToppingsData[ingredientsNum].InvenAmount;

            AudioManager.GetInstance().PlaySfx("BuyCoin");
        }
        else if (playerData.money >= buyprice && shopdataChecker.CheckNum == 1)
        {
            playerData.money -= buyprice;
            _BaseIngredientData[ingredientsNum].ShopAmount -= buyAmount;
            _BaseIngredientData[ingredientsNum].InvenAmount += buyAmount;
            BuyBaseCountReset();
            inventory.GetComponent<Inventory>().BuyInvenBaseCountReset(ingredientsNum);
            mainbaord.GetComponent<MainBoard>().money.text = playerData.money.ToString();
            GameManager.GetInstance()._BaseInvenAcount[ingredientsNum] = _BaseIngredientData[ingredientsNum].InvenAmount;

            AudioManager.GetInstance().PlaySfx("BuyCoin");

            Debug.Log(GameManager.GetInstance()._BaseInvenAcount[ingredientsNum]);
        }
        else if (playerData.money < buyprice)
        {
            AudioManager.GetInstance().PlaySfx("Error");
            shortageMoney.gameObject.SetActive(true);
            Debug.Log("돈이 부족합니다.");
        }

        ShopMyMoneySetUp();
        // inventory.InvenMyMoneySetUp();
        buyAmount = 0;
        buyprice = 0;
        CheckBoxTxt();
        buyCheckbox.SetActive(false);

        //Debug.Log(_ToppingsData[ingredientsNum].InvenAmount);
        //Debug.Log(_BaseIngredientData[ingredientsNum].InvenAmount);
    }


    public void BuyBaseCountReset()
    {
        for (int k = 0; k < _BaseIngredientData.Count; k++)
        {
            shopingredientCounttxts[k].text = _BaseIngredientData[k].ShopAmount.ToString();
        }
    }

    public void BuyToppingCountReset()
    {
        for (int k = 0; k < _ToppingsData.Count; k++)
        {
            shopingredientCounttxts[k].text = _ToppingsData[k].ShopAmount.ToString();
        }
    }



    public void ShopMyMoneySetUp()   // 보유자산
    {
        myMoney.text = playerData.money.ToString();
    }

    public void BuyCheckBoxOnClick()   // 구매 체크박스 온클릭 체크
    {
        countup.onClick.AddListener(ShoppingBasketUp);
        countdown.onClick.AddListener(ShoppingBasketDown);
        cancle.onClick.AddListener(BuyCheckBoxHide);
        buy.onClick.AddListener(BuyItem);
        nomoneyCancle.onClick.AddListener(NoMoneyBoxCheck);
    }

    public void NoMoneyBoxCheck()
    {
        AudioManager.GetInstance().PlaySfx("Click");
        shortageMoney.gameObject.SetActive(false);
    }

    public void CheckBoxTxt()  // 구매 체크박스 텍스트
    {
        buyCount.text = buyAmount.ToString();
        sumMoney.text = buyprice.ToString("F2");
    }


    public void ShoppingBasketUp()   // 체크박스 구매 갯수 플러스 가격
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
        if (shopdataChecker.CheckNum == 0 && _ToppingsData[ingredientsNum].ShopAmount > buyAmount)
        {
            buyprice += _shopToppingPrice[ingredientsNum];
            buyAmount += 1;
        }
        else if (shopdataChecker.CheckNum == 1 && _BaseIngredientData[ingredientsNum].ShopAmount > buyAmount)
        {
            buyprice += _shopBasePrice[ingredientsNum];
            buyAmount += 1;
        }

        else
            Debug.Log("상품이 부족합니다.");

        CheckBoxTxt();
    }

    public void ShoppingBasketDown()   // 체크박스 구매 갯수 마이너스
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
        if (shopdataChecker.CheckNum == 0 && buyAmount > 0)
        {
            buyprice -= _shopToppingPrice[ingredientsNum];
            buyAmount -= 1;
        }
        else if (shopdataChecker.CheckNum == 1 && buyAmount > 0)
        {
            buyprice -= _shopBasePrice[ingredientsNum];
            buyAmount -= 1;
        }

        CheckBoxTxt();
    }
}
