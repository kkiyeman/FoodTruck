using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public string name;
    public int repute;
    public int money;
    //public List<Ingredient> inventory;
    public int customTruck;
    //��������� �߰��Ǿ����..

    public Player(string name, int repute, int money, int customTruck)
    {
        this.name = name;
        this.repute = repute;
        this.money = money;
        //this.inventory = inventory;
        this.customTruck = customTruck;
    }
}
