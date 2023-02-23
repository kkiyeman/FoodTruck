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
        AudioManager.GetInstance().PlayBgm("GarageBGM");
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
            AudioManager.GetInstance().PlaySfx("Click");
            saleInfo.gameObject.SetActive(true);
        });

        saleInfo.onClick.AddListener(() =>
        {
            AudioManager.GetInstance().PlaySfx("Click");
            saleInfo.gameObject.SetActive(false);
        });
    }

    public void ClickOpenInven()
    {
        openInven.onClick.AddListener(() =>
        {
            AudioManager.GetInstance().PlaySfx("Click");
            inventory.gameObject.SetActive(true);
        });
    }


    public void GoBusinessOnClick()
    {
        goPark.onClick.AddListener(() =>
        {
            goParkCheckBox.gameObject.SetActive(true);
            AudioManager.GetInstance().PlaySfx("Click");
        });

        goParkYes.onClick.AddListener(BusinessEvent);

        goParkNo.onClick.AddListener(() =>
        {
            goParkCheckBox.gameObject.SetActive(false);
            AudioManager.GetInstance().PlaySfx("Click");
        });
    }

    public void BusinessEvent()
    {
        AudioManager.GetInstance().PlaySfx("TruckStartUp");
        Invoke("GoParkChange", 3.0f);
        //sceneLoad.SceneChangePark();

    }

    //public void TruckStartUpSound()
    //{
    //    AudioManager.GetInstance().PlaySfx("TruckStartUp");
    //}

    public void GoParkChange()
    {
        sceneLoad.SceneChangePark();
    }

    public void StartSceneClick()
    {
        AudioManager.GetInstance().PlaySfx("Click");
        Invoke("GoStartScene", 1.0f);
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
            AudioManager.GetInstance().PlaySfx("Click");
        });

        goEventCheckBox.onClick.AddListener(() =>
        {
            goEventCheckBox.gameObject.SetActive(false);
            AudioManager.GetInstance().PlaySfx("Click");
        });
    }


    public void SettingOnClick()
    {
        AudioManager.GetInstance().PlaySfx("SimpleClick");
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