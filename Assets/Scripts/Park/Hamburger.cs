using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hamburger
{
    public string Name { get; protected set; }
    public string[] Recipe { get; protected set; }

    public abstract void SetInfo();
}

public class Burger : Hamburger
{

    public Burger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "ÇÜ¹ö°Å";
        Recipe = new string[5]
        {
            "À­»§",
            "¾Æ·§»§",
            "°í±â",
            "¾ç»óÃß",
            "Åä¸¶Åä"
        };
    }

}

public class CheeseBurger : Hamburger
{

    public CheeseBurger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "Ä¡Áî¹ö°Å";
        Recipe = new string[6]
        {
            "À­»§",
            "¾Æ·§»§",
            "°í±â",
            "¾ç»óÃß",
            "Åä¸¶Åä",
            "Ä¡Áî"
        };
    }
}

public class VeganBurger : Hamburger
{
    public VeganBurger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "ºñ°Ç¹ö°Å";
        Recipe = new string[4]
        {
            "À­»§",
            "¾Æ·§»§",
            "¾ç»óÃß",
            "Åä¸¶Åä"
        };
    }
}

public class MeetBurger : Hamburger
{
    public MeetBurger()
    {
        SetInfo();
    }
    public override void SetInfo()
    {
        Name = "°í±â¹ö°Å";
        Recipe = new string[4]
        {
            "À­»§",
            "¾Æ·§»§",
            "°í±â",
            "Ä¡Áî"
        };
    }
}

