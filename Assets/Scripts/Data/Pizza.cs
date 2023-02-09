using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza
{
    public string pizzaName;
    public float price;
    public string[] recipe;

    public Pizza(string pizzaName, float price, string[] recipe)
    {
        this.pizzaName = pizzaName;
        this.price = price;
        this.recipe = recipe;
    }
}
