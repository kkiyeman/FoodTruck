using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerSingle : ConsumerBase
{
    public ConsumerSingle(int order, int pay, int satisfaction, bool giveTip)
    {
        this.order = order;
        this.pay = pay;
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
    }

    public void Order()
    {

    }

}
