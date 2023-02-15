using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckColor 
{
    public string name;
    public int trucks;
    public bool kimTruckBuycolor;
    public bool leeTrcukBuycolor;
    public bool kimTruckColor;
    public bool leeTruckColor;
    

    public TruckColor(string name, int trucks, bool kimTruckBuycolor, bool leeTrcukBuycolor, bool kimTruckColor, bool leeTruckColor)
    {
        this.name = name;
        this.trucks = trucks;
        this.kimTruckBuycolor = kimTruckBuycolor;
        this.leeTrcukBuycolor = leeTrcukBuycolor;
        this.kimTruckColor = kimTruckColor;
        this.leeTruckColor = leeTruckColor;
    }
}
