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
    private int curOrder = 0;

    void Start()
    {

    }

    public void Order()
    {
        if(curOrder < 2)
        {
            ConsumerBase2 consumerData = ConsumerManager.GetInstance().GetRandomConsumer();

            List<string> orderPizza = consumerData.Order();
            int orderPizzaCnt = consumerData.OrderPizzaCnt();

            UIManager.GetInstance().OpenUI("uiOrder");

            GameObject uiOrder = UIManager.GetInstance().SetUI("uiOrder");
            Text txtOrder = uiOrder.GetComponentInChildren<Text>();

            if (orderPizza.Count > 1)
            {
                txtOrder.text = $"{orderPizza[0]} {orderPizzaCnt}판, \n{orderPizza[1]} {orderPizzaCnt}판";
            }
            else
                txtOrder.text = $"{orderPizza[0]} {orderPizzaCnt}판";
            
            curOrder++;
        }
        else
            Debug.Log("주문불가");
    }

    //피자 제공
    public void ServePizza()
    {
        ObjectPoolManager.GetInstance().ReturnToConsumerPool();
        curOrder--;
    }
}
