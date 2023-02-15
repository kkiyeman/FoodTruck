using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingsData
{
    public string Name { get; protected set; }
    public float Price { get; set; }
    public int Amount { get; set; }
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

public class ShopPepperoni : ToppingsData
{
    public ShopPepperoni()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "���۷δ�";
        Price = 0.6f;
        Amount = 10;
    }
}

public class ShopBacon : ToppingsData
{
    public ShopBacon()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "������";
        Price = 0.8f;
        Amount = 10;
    }
}

public class ShopPotato : ToppingsData
{
    public ShopPotato()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "��������";
        Price = 0.2f;
        Amount = 10;
    }
}


public class ShopPineapple : ToppingsData
{
    public ShopPineapple()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "���ξ���";
        Price = 0.4f;
        Amount = 10;
    }
}


public class ShopOlive : ToppingsData
{
    public ShopOlive()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�ø���";
        Price = 0.4f;
        Amount = 10;
    }
}


public class ShopMushroom : ToppingsData
{
    public ShopMushroom()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "����";
        Price = 0.4f;
        Amount = 10;
    }
}


public class ShopPepper : ToppingsData
{
    public ShopPepper()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�Ǹ�";
        Price = 0.4f;
        Amount = 10;
    }
}


//////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////



public class InvenPepperoni : ToppingsData
{
    public InvenPepperoni()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "���۷δ�";
        Amount = 0;
    }
}

public class InvenBacon : ToppingsData
{
    public InvenBacon()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "������";
        Amount = 0;
    }
}

public class InvenPotato : ToppingsData
{
    public InvenPotato()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "��������";
        Amount = 0;
    }
}


public class InvenPineapple : ToppingsData
{
    public InvenPineapple()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "���ξ���";
        Amount = 0;
    }
}


public class InvenOlive : ToppingsData
{
    public InvenOlive()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�ø���";
        Amount = 0;
    }
}


public class InvenMushroom : ToppingsData
{
    public InvenMushroom()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "����";
        Amount = 0;
    }
}


public class InvenPepper : ToppingsData
{
    public InvenPepper()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "�Ǹ�";
        Amount = 0;
    }
}