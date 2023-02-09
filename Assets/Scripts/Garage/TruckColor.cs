using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckColor 
{
    public string name;
    public bool buycolor;
    public bool color;
    

    public TruckColor(string name, bool buycolor, bool color)
    {
        this.name = name;
        this.buycolor = buycolor;
        this.color = color;
    }
}
