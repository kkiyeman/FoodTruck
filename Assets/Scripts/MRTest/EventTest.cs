using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTest : MonoBehaviour
{
    //ConsumerManager consumerManager;
    //ConsumerBase2 consumerData;
    //List<string> orderPizza;
    //int orderPizzaCnt;

    //UIManager uiManager;
    //public Text txtOrder;

    void Start()
    {

    }

    public void Order()
    {
        ConsumerBase2 consumerData = ConsumerManager.GetInstance().GetRandomConsumer();

        List<string> orderPizza = consumerData.Order();
        int orderPizzaCnt = consumerData.OrderPizzaCnt();

        UIManager.GetInstance().OpenUI("uiOrder");

        GameObject uiOrder = UIManager.GetInstance().SetUI("uiOrder");
        Text txtOrder = uiOrder.GetComponentInChildren<Text>();

        if (orderPizza.Count > 1)
        {
            txtOrder.text = $"{orderPizza[0]} {orderPizzaCnt}ÆÇ, \n{orderPizza[1]} {orderPizzaCnt}ÆÇ";
        }
        else
            txtOrder.text = $"{orderPizza[0]} {orderPizzaCnt}ÆÇ";
    }
}
