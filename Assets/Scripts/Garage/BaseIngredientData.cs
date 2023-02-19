using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseIngredientData
{
    public string Name { get; protected set; }
    public float Price { get;  set; }
    public int ShopAmount { get;  set; }
    public int InvenAmount { get; set; }
    public abstract void SetInfo();
}

public class Dow : BaseIngredientData
{
    public Dow()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Dow";
        Price = 4.0f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}

public class Sauce : BaseIngredientData
{
    public Sauce()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Sauce";
        Price = 5.0f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}

public class Cheese : BaseIngredientData
{
    public Cheese()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Cheese";
        Price = 6.0f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}

public class Corn : BaseIngredientData
{
    public Corn()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Corn";
        Price = 3.0f;
        ShopAmount = 10;
        InvenAmount = 0;
    }
}

