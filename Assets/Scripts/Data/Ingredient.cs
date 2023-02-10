using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public string name;
    public float price;
    public int shopAmount;
    public int inPlayerInven;
    public bool sale;

    public Ingredient(string name, float price, int shopAmount, int inPlayerInven, bool sale)
    {
        this.name = name;
        this.price = price;
        this.shopAmount = shopAmount;
        this.inPlayerInven = inPlayerInven;
        this.sale = sale;
    }
}
