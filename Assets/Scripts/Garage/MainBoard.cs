using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainBoard : MonoBehaviour
{
    public Button goPark;
    public Button goParkYes;
    public Button goParkNo;
    public Button goEvent;
    public Button goEventYes;
    public Button goEventNo;
    public Button openInven;
    public TMP_Text date;
    public TMP_Text money;
    public TMP_Text eventInfo;
    public TMP_Text saleInfo;
    public GameObject goParkCheckBox;
    public GameObject goEventCheckBox;
    public GameObject inventory;


    SceneLoadTester sceneLoad = new SceneLoadTester();
    public void Awake()
    {
        
    }

    public void Start()
    {
        ClickgoPark();
        ClickGoEvent();
        ClickOpenInven();
    }


    public void ClickOpenInven()
    {
        openInven.onClick.AddListener(() =>
        {
            inventory.SetActive(true);
        });
    }


    public void ClickgoPark()
    {
        goPark.onClick.AddListener(() =>
        {
            goParkCheckBox.SetActive(true);
        });

        goParkYes.onClick.AddListener(sceneLoad.SceneChangePark);

        goParkNo.onClick.AddListener(() =>
        {
            goParkCheckBox.SetActive(false);
        });
    }


    public void ClickGoEvent()
    {
        goEvent.onClick.AddListener(() =>
        {
            goEventCheckBox.SetActive(true);
        });

        //goEventYes.onClick.AddListener(ChangeSceneGoEvent);

        goEventNo.onClick.AddListener(() =>
        {
            goEventCheckBox.SetActive(false);
        });
    }

    
    public void ChangeSceneGoPark()
    {
        goParkCheckBox.SetActive(false);
    }


    public void ChangeSceneGoEvent()
    {
        goEventCheckBox.SetActive(false);
    }


    public void SceneSetUp()
    {
        // date.text = dateData
        // money.text = moneyData
        // saleInfo.text = shopsaleData
    }
}
