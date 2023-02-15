using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseIngredientData
{
    public string Name { get; protected set; }
    public float Price { get; protected set; }
    public int Amount { get; protected set; }
    public abstract void SetInfo();
}

public class ShopDough : BaseIngredientData
{
    public ShopDough()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "����";
        Price = 4.0f;
        Amount = 10;
    }
}

public class ShopSauce : BaseIngredientData
{
    public ShopSauce()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�ҽ�";
        Price = 5.0f;
        Amount = 10;
    }
}

public class ShopCheeses : BaseIngredientData
{
    public ShopCheeses()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "ġ��";
        Price = 6.0f;
        Amount = 10;
    }
}

public class ShopCorn : BaseIngredientData
{
    public ShopCorn()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "��";
        Price = 3.0f;
        Amount = 10;
    }
}


////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////


public class InvenDough : BaseIngredientData
{
    public InvenDough()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "����";
        Amount = 10;
    }
}

public class InvenSauce : BaseIngredientData
{
    public InvenSauce()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�ҽ�";
        Amount = 10;
    }
}

public class InvenCheeses : BaseIngredientData
{
    public InvenCheeses()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "ġ��";
        Amount = 10;
    }
}

public class InvenCorn : BaseIngredientData
{
    public InvenCorn()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "��";
        Amount = 10;
    }
}

