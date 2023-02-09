using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public string Name;
    public float price;
    public int amount;

    public Ingredient(string Name, float price, int amount)
    {
        this.Name = Name;
        this.price = price;
        this.amount = amount;
    }
}
