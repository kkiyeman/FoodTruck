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

    public Button setting;
    public GameObject settingDrop;
    public Button goStartScene;

    public GameObject inventory;
    public GameObject shop;


    SceneLoadTester sceneLoad = new SceneLoadTester();
    public void Awake()
    {
        SceneSetUp();
    }

    public void Start()
    {
        ClickGoEvent();
        ClickOpenInven();
        DailySaleOnClick();
        GoBusinessOnClick();
        ClickGoEvent();
        ClickCheck();
    }

    public void SceneSetUp()
    {
        money.text = shop.GetComponent<Shop>().playerData.money.ToString();
    }

    public void ClickCheck()
    {
        setting.onClick.AddListener(SettingOnClick);
        goStartScene.onClick.AddListener(GoStartScene);
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


    public void GoBusinessOnClick()
    {
        goPark.onClick.AddListener(() =>
        {
            goParkCheckBox.gameObject.SetActive(true);
        });

        goParkYes.onClick.AddListener(BusinessEvent);

        goParkNo.onClick.AddListener(() =>
        {
            goParkCheckBox.gameObject.SetActive(false);
        });
    }

    public void BusinessEvent()
    {
        sceneLoad.SceneChangePark();
    }

    public void GoStartScene()
    {
        sceneLoad.SceneChangeStart();
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


    public void SettingOnClick()
    {
        if (settingDrop.activeSelf == false)
        {
            settingDrop.SetActive(true);
        }

        else if (settingDrop.activeSelf == true)
        {
            settingDrop.SetActive(false);
        }
    }
}