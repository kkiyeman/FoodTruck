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
        Name = "페퍼로니";
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
        Name = "베이컨";
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
        Name = "포테이토";
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
        Name = "파인애플";
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
        Name = "올리브";
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
        Name = "버섯";
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
        Name = "피망";
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
        Name = "페퍼로니";
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
        Name = "베이컨";
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
        Name = "포테이토";
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
        Name = "파인애플";
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
        Name = "올리브";
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
        Name = "버섯";
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
        Name = "피망";
        Amount = 0;
    }
}