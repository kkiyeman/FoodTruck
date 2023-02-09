using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTruck : MonoBehaviour
{
    public List<TruckColor> truckColors;
    public void ColorChange()
    {
        truckColors = new List<TruckColor>();

        truckColors.Add(new TruckColor("Red", false, false));
        truckColors.Add(new TruckColor("Black", false, false));
        truckColors.Add(new TruckColor("Yellow", false, false));
    }
}


abstract class Truck
{
    FoodTruck foodTruck = new FoodTruck();
    public void BuyRedColor()
    {
        Debug.Log("����@@");

        foodTruck.truckColors[0].buycolor = true;
    }

    public void BuyBlackColor()
    {
        Debug.Log("��@@");

        foodTruck.truckColors[1].buycolor = true;
    }

    public void BuyYellowColor()
    {
        Debug.Log("���ο�@@");

        foodTruck.truckColors[2].buycolor = true;
    }
    public void ChangeColorRed()
    {
        Debug.Log("����@@");

        foodTruck.truckColors[0].color = true;
    }

    public void ChangeColorBlack()
    {
        Debug.Log("��@@");

        foodTruck.truckColors[1].color = true;
    }

    public void ChangeColorYellow()
    {
        Debug.Log("���ο�@@");

        foodTruck.truckColors[2].color = true;
    }
}

class SimpleTruck : Truck
{
    
}

class NeonTruck : Truck
{
   
}



