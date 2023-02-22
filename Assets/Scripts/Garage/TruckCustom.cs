using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TruckCustom : MonoBehaviour
{
    public GameObject truckG;
    public MeshRenderer[] _truckColorsChange;

    public GameObject truckColorBtnG;
    private Button[] _truckColorBtns;
    public Image[] _lockImage;

    public GameObject colorBuyCheckBox;
    public Button buyYes;
    public Button buyNo;

    public GameObject shortageMoney;
    public Button shortageMoneyCheckBtn;

    public Material[] _truckMats;

    public TMP_Text myMoney;

    public int idx;

    PlayerData playerData = new PlayerData();

    public List<FoodTruckData> _FoodTruckSimpleList = new List<FoodTruckData>();
    SimpleTruck simpleTruck = new SimpleTruck();

    public void Awake()
    {
        FoodTruckDataList();
        TruckSetUp();
    }

    public void Start()
    {
        ColorClick();
        CheckBoxClick();
    }


    public void ColorClick()
    {
        for (int i = 0; i < _truckColorBtns.Length; i++)
        {
            int c = i;
            _truckColorBtns[i].onClick.AddListener(() =>
            {
                ChangeTruckMat(c);
            });
        }
    }

    public void CheckBoxClick()
    {
        buyYes.onClick.AddListener(BuyYes);
        buyNo.onClick.AddListener(BuyNo);
        shortageMoneyCheckBtn.onClick.AddListener(ShortageMoneyCheck);
    }
    public void FoodTruckDataList()
    {
        SimpleColorTruck simpleTruck = new SimpleColorTruck();
        BlackColorTruck blackTruck = new BlackColorTruck();
        PinkColorTruck pinkTruck = new PinkColorTruck();
        BlueColorTruck blueTruck = new BlueColorTruck();
        RedColorTruck redTruck = new RedColorTruck();



        _FoodTruckSimpleList.Add(simpleTruck);
        _FoodTruckSimpleList.Add(blackTruck);
        _FoodTruckSimpleList.Add(pinkTruck);
        _FoodTruckSimpleList.Add(blueTruck);
        _FoodTruckSimpleList.Add(redTruck);
    }

    public void ShortageMoneyCheck()
    {
        AudioManager.GetInstance().PlaySfx("Click");
        shortageMoney.gameObject.SetActive(false);
    }

    public void BuyYes()
    {
        if (_FoodTruckSimpleList[idx].Price <= playerData.money)
        {
            AudioManager.GetInstance().PlaySfx("BuyCoin");
            _lockImage[idx].gameObject.SetActive(false);
            _FoodTruckSimpleList[idx].BuyCheck = true;
            playerData.money -= _FoodTruckSimpleList[idx].Price;
            colorBuyCheckBox.gameObject.SetActive(false);
        }

        else
        {
            AudioManager.GetInstance().PlaySfx("Error");
            shortageMoney.gameObject.SetActive(true);
            colorBuyCheckBox.gameObject.SetActive(false);
        }

    }

    public void BuyNo()
    {
        AudioManager.GetInstance().PlaySfx("Click");
        colorBuyCheckBox.gameObject.SetActive(false);
    }

    public void TruckSetUp()
    {
        _truckColorBtns = new Button[truckColorBtnG.GetComponentsInChildren<Button>().Length];
        _truckColorsChange = new MeshRenderer[truckG.GetComponentsInChildren<MeshRenderer>().Length];
        _truckMats = Resources.LoadAll<Material>("Material");
        myMoney.text = playerData.money.ToString();

        for (int i = 0; i < truckColorBtnG.GetComponentsInChildren<Button>().Length; i++)
        {
            _truckColorBtns[i] = truckColorBtnG.GetComponentsInChildren<Button>()[i];
        }

        for (int i = 0; i < truckG.GetComponentsInChildren<MeshRenderer>().Length; i++)
        {
            _truckColorsChange[i] = truckG.GetComponentsInChildren<MeshRenderer>()[i];
        }

        for (int m = 0; m < truckG.GetComponentsInChildren<MeshRenderer>().Length; m++)
        {
            
            _truckColorsChange[m].gameObject.GetComponent<MeshRenderer>().material = _truckMats[simpleTruck.ColorNum];

        }

        for (int k = 0; k < truckColorBtnG.GetComponentsInChildren<Button>().Length; k++)
        {
            if (_FoodTruckSimpleList[k].BuyCheck == true)
            {
                _lockImage[k].gameObject.SetActive(false);
            }
        }
    }

    public void ColorBuyCheck()
    {
        
    }

    public void ChangeTruckMat(int c)
    {
        idx = c;
        if (_FoodTruckSimpleList[idx].BuyCheck == true)
        {
            AudioManager.GetInstance().PlaySfx("ChangeClick");
            for (int i = 0; i < truckG.GetComponentsInChildren<MeshRenderer>().Length; i++)
            {
                _truckColorsChange[i].gameObject.GetComponent<MeshRenderer>().material = _truckMats[idx];
            }
            simpleTruck.ColorNum = idx;
        }
        else if (_FoodTruckSimpleList[idx].BuyCheck == false)
        {
            AudioManager.GetInstance().PlaySfx("Click");
            colorBuyCheckBox.gameObject.SetActive(true);
        }
        Debug.Log($"선택된 번호 : {idx}");
    }
}