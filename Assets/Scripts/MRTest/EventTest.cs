using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTest : MonoBehaviour
{
    ConsumerManager consumerManager;
    ConsumerBase2 consumerData;
    public Text txtOrder;

    void Start()
    {
        consumerManager = ConsumerManager.GetInstance();
        consumerData = consumerManager.GetRandomConsumer();

        //consumerData.Order();
        //consumerData.Pay();

        txtOrder.text = $"{consumerData.Order()}";
    }
}
