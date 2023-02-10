using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase
{
    public int orderIdx;
    public int pay;
    public int satisfaction;
    public bool giveTip;

    public PizzaManager pizzaManager;

    public void Init() 
    {
        pizzaManager = PizzaManager.GetInstance();
    }
    public virtual void Order()
    {
        Debug.Log("林巩");
    }
}


public class ConsumerSingle : ConsumerBase
{
    public ConsumerSingle(int orderIdx, int pay, int satisfaction, bool giveTip)
    {
        this.orderIdx = orderIdx;
        this.pay = pay;
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerSingle 林巩");
        string orderedPizza = pizzaManager.GetPizzaList(orderIdx).pizzaName;
        Debug.Log(orderedPizza);
    }
}

public class ConsumerDouble : ConsumerBase
{
    public ConsumerDouble(int orderIdx, int pay, int satisfaction, bool giveTip)
    {
        this.orderIdx = orderIdx;
        this.pay = pay;
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerSingle 林巩");
        string orderedPizza = pizzaManager.GetPizzaList(orderIdx).pizzaName;
        Debug.Log(orderedPizza);
    }
}

public class ConsumerTriple : ConsumerBase
{
    public ConsumerTriple(int orderIdx, int pay, int satisfaction, bool giveTip)
    {
        this.orderIdx = orderIdx;
        this.pay = pay;
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerSingle 林巩");
        string orderedPizza = pizzaManager.GetPizzaList(orderIdx).pizzaName;
        Debug.Log(orderedPizza);
    }
}
