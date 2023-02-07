using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ingredients
{
    public string Name{ get; protected set;}
    public int Price { get; protected set; }

    public abstract void SetInfo();
}

public class UpperBread : Ingredients
{
    public UpperBread()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "¿≠ªß";
        Price = 500;
    }
}

public class Lettuce : Ingredients
{
    public Lettuce()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "æÁªÛ√ﬂ";
        Price = 700;
    }

}

public class Tomato : Ingredients
{
    public Tomato()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "≈‰∏∂≈‰";
        Price = 600;
    }

}

public class Cheese : Ingredients
{
    public Cheese()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "ƒ°¡Ó";
        Price = 300;
    }

}

public class Patty : Ingredients
{
    public Patty()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "∞Ì±‚";
        Price = 800;
    }

}

public class LowerBread : Ingredients
{
    public LowerBread()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "æ∆∑ßªß";
        Price = 500;
    }

}
