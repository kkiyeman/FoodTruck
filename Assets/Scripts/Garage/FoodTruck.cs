using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTruck : MonoBehaviour
{
    public List<TruckColor> truckColors;
 
    public void Awake()
    {
        ColorCheck();
    }

    public void ColorCheck()
    {
        truckColors = new List<TruckColor>();

        truckColors.Add(new TruckColor("Red",0, false, false, false, false));
        truckColors.Add(new TruckColor("Black",0, false, false, false, false));
        truckColors.Add(new TruckColor("Yellow",0, false, false, false, false));
    }
}


abstract class Truck
{
    FoodTruck foodTruck = new FoodTruck();
    public void BuyRedColor()
    {
        Debug.Log("����@@");
        // if(money > 10000 && )
        // { money =- 10000
        foodTruck.truckColors[0].kimTruckBuycolor = true;
        // }
    }

    public void BuyBlackColor()
    {
        Debug.Log("��@@");
        // if(money > 10000)
        // { money =- 10000
        foodTruck.truckColors[1].kimTruckBuycolor = true;
        // }
    }

    public void BuyYellowColor()
    {
        Debug.Log("���ο�@@");
        // if(money > 10000)
        // { money =- 10000
        foodTruck.truckColors[2].kimTruckBuycolor = true;
        // }
    }
    public void ChangeColorRed()
    {
        Debug.Log("����@@");

        
    }

    public void ChangeColorBlack()
    {
        Debug.Log("��@@");

        
    }

    public void ChangeColorYellow()
    {
        Debug.Log("���ο�@@");

        
    }
}

class SimpleTruck : Truck
{
    
}

class NeonTruck : Truck
{
   
}



