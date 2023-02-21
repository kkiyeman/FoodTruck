using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public Text name;
    public Text repute;
    public Text money;

    void Start()
    {
        name.text += DataManager.instance.nowPlayer.name;
        repute.text += DataManager.instance.nowPlayer.repute.ToString();
        money.text += DataManager.instance.nowPlayer.money.ToString();
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }

}