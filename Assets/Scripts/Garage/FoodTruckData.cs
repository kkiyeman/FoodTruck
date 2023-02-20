using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FoodTruckData
{
    public string Name { get; protected set; }
    public float Price { get; set; }
    public bool BuyCheck { get; set; }
    public int ColorNum { get; set; }
    public abstract void SetInfo();
}

public class SimpleTruck : FoodTruckData
{
    public SimpleTruck()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "기본트럭";
        Price = 0.0f;
        ColorNum = 0;
    }
}

public class SimpleColorTruck : FoodTruckData
{
    public SimpleColorTruck()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        BuyCheck = true;
        Price = 0.0f;
    }
}

public class BlackColorTruck : FoodTruckData
{
    public BlackColorTruck()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        BuyCheck = false;
        Price = 200.0f;
    }
}

public class PinkColorTruck : FoodTruckData
{
    public PinkColorTruck()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        BuyCheck = false;
        Price = 200.0f;
    }
}

public class BlueColorTruck : FoodTruckData
{
    public BlueColorTruck()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        BuyCheck = false;
        Price = 200.0f;
    }
}

public class RedColorTruck : FoodTruckData
{
    public RedColorTruck()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        BuyCheck = false;
        Price = 200.0f;
    }
}
