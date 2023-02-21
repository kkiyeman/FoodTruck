using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public int repute;
    public float money;
    //public List<Ingredient> inventory;
    //장사일지도 추가되어야함..

    public Player(string name, int repute, float money)
    {
        this.name = name;
        this.repute = repute;
        this.money = money;
        //this.inventory = inventory;
    }
}