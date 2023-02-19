using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingsData
{
    public string Name { get; protected set; }
    public float Price { get; set; }
    public int ShopAmount { get; set; }
    public int InvenAmount { get; set; }
    public int CheckNum { get; set; }
    public abstract void SetInfo();
}

public class ShopDataChecker : ToppingsData
{
    public ShopDataChecker()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        CheckNum = 0;
    }
}

public class Pepperoni : ToppingsData
{
    public Pepperoni()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Pepperoni";
        Price = 0.6f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}

public class Bacon : ToppingsData
{
    public Bacon()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Bacon";
        Price = 0.8f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}

public class Potato : ToppingsData
{
    public Potato()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Potato";
        Price = 0.2f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}


public class Pineapple : ToppingsData
{
    public Pineapple()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Pineapple";
        Price = 0.4f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}


public class Olive : ToppingsData
{
    public Olive()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Olive";
        Price = 0.4f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}


public class Mushroom : ToppingsData
{
    public Mushroom()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Mushroom";
        Price = 0.4f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}


public class Pepper : ToppingsData
{
    public Pepper()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Pepper";
        Price = 0.4f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}