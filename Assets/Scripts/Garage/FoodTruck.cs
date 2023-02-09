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
        Debug.Log("레드@@");

        foodTruck.truckColors[0].buycolor = true;
    }

    public void BuyBlackColor()
    {
        Debug.Log("블랙@@");

        foodTruck.truckColors[1].buycolor = true;
    }

    public void BuyYellowColor()
    {
        Debug.Log("옐로우@@");

        foodTruck.truckColors[2].buycolor = true;
    }
    public void ChangeColorRed()
    {
        Debug.Log("레드@@");

        foodTruck.truckColors[0].color = true;
    }

    public void ChangeColorBlack()
    {
        Debug.Log("블랙@@");

        foodTruck.truckColors[1].color = true;
    }

    public void ChangeColorYellow()
    {
        Debug.Log("옐로우@@");

        foodTruck.truckColors[2].color = true;
    }
}

class SimpleTruck : Truck
{
    
}

class NeonTruck : Truck
{
   
}



