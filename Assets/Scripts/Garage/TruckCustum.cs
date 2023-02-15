using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TruckCustum : MonoBehaviour
{
    public Button exit;
    public Button[] trucksBtn;
    public Button[] colorsBtn;
    public Button[] colorBuyBtn;
    public Button kimTruckBtn;
    public Button leeTruckBtn;
    public Button redTruckBtn;
    public Button blueTruckBtn;
    public GameObject colorsBtns;
    public GameObject colorsBuyBtns;
    public GameObject kimTruck;
    FoodTruck foodTruck;


    public void Awake()
    {
        
    }

    public void Start()
    {
        
    }

    public void RedColorClick()
    {
        var getTruck = foodTruck.truckColors[0];

        SimpleTruck simpleTruck = new SimpleTruck();

        if (getTruck.kimTruckBuycolor == false && getTruck.trucks == 0)
        {
            simpleTruck.BuyRedColor();
        }

        else if (getTruck.kimTruckBuycolor == true && getTruck.trucks == 0)
        {
            simpleTruck.ChangeColorRed();


        }
    }

    public void TruckCheck()
    {

    }

    public void BtnSetUp()
    {
        
    }
}
