using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainBoard : MonoBehaviour
{
    public GameObject goParkCheckBox;
    public Button goPark;
    public Button goParkYes;
    public Button goParkNo;
   
    public Button openInven;

    public TMP_Text date;
    public TMP_Text money;
    public TMP_Text sale_1;
    public TMP_Text sale_2;

    public Button saleInfo;
    public Button gosale;
    public Button goEventCheckBox;
    public Button goEvent;

    public GameObject inventory;
    public GameObject shop;


    SceneLoadTester sceneLoad = new SceneLoadTester();
    public void Awake()
    {
        SceneSetUp();
    }

    public void Start()
    {
        ClickgoPark();
        ClickGoEvent();
        ClickOpenInven();
        DailySaleOnClick();
    }

    public void SceneSetUp()
    {
        //date.text = dateData
        money.text = shop.GetComponent<Shop>().playerData.money.ToString();
    }

    public void DailySaleOnClick()
    {
        gosale.onClick.AddListener(() =>
        {
            saleInfo.gameObject.SetActive(true);
        });

        saleInfo.onClick.AddListener(() =>
        {
            saleInfo.gameObject.SetActive(false);
        });
    }

    public void ClickOpenInven()
    {
        openInven.onClick.AddListener(() =>
        {
            inventory.gameObject.SetActive(true);
        });
    }


    public void ClickgoPark()
    {
        goPark.onClick.AddListener(() =>
        {
            goParkCheckBox.gameObject.SetActive(true);
        });

        goParkYes.onClick.AddListener(sceneLoad.SceneChangePark);

        goParkNo.onClick.AddListener(() =>
        {
            goParkCheckBox.gameObject.SetActive(false);
        });
    }


    public void ClickGoEvent()
    {
        goEvent.onClick.AddListener(() =>
        {
            goEventCheckBox.gameObject.SetActive(true);
        });

        goEventCheckBox.onClick.AddListener(() =>
        {
            goEventCheckBox.gameObject.SetActive(false);
        });
    }

    
    //public void GoBusinessOnClick()
    //{
    //    goParkCheckBox.SetActive(false);
    //}

    
}
