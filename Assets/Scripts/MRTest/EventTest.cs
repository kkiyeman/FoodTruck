using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    public ConsumerManager consumerManager;
    public ConsumerBase2 consumerData;

    void Start()
    {
        consumerManager = ConsumerManager.GetInstance();
        consumerData = consumerManager.GetRandomConsumer();

        consumerData.Order();
        consumerData.Pay();
    }

}
