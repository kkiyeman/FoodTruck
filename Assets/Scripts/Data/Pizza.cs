using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza
{
    public string Name { get; set; }
    public float Price { get; set; }
    public string[] Recipe { get; set; }

    public Pizza(string pizzaName, float price, string[] recipe)
    {
        Name = pizzaName;
        Price = price;
        Recipe = recipe;
    }
}
