using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase
{
    public int satisfaction;
    public bool giveTip;
    public int tip;

    public PizzaManager pizzaManager;
    public PlayerManager playerManager;

    public void Init() 
    {
        pizzaManager = PizzaManager.GetInstance();
    }

    public virtual void Order()
    {
        
    }

    public virtual void GiveTip()
    {
        
    }
}

//1�� �ֹ� �մ�
public class ConsumerSingle : ConsumerBase
{
    public ConsumerSingle(int satisfaction, bool giveTip, int tip)
    {
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
        this.tip = tip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerSingle �ֹ�");
        int i = Random.Range(0, 4);
        string orderPizza = pizzaManager.GetPizzaList(i).pizzaName;
        Debug.Log(orderPizza);
    }

    public override void GiveTip()
    {
        if(giveTip == true)
        {
            playerManager.player.money += tip;
        }
    }
}

//2�� �ֹ� �մ�
public class ConsumerDouble : ConsumerBase
{
    public ConsumerDouble(int satisfaction, bool giveTip, int tip)
    {
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
        this.tip = tip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerDouble �ֹ�");
        object orderPizza1st;
        object orderPizza2nd;

        for(int i = 0; i < 2; i++)
        {
            int pizzaIdx = Random.Range(0, 4);
            orderPizza1st = pizzaManager.GetPizzaList(pizzaIdx);
            string orderPizza = pizzaManager.GetPizzaList(pizzaIdx).pizzaName;
            Debug.Log(orderPizza);
        }

    }

}

//3���ֹ� �մ�
public class ConsumerTriple : ConsumerBase
{
    //public ConsumerTriple(int orderIdx, int pay, int satisfaction, bool giveTip)
    //{
    //    this.orderIdx = orderIdx;
    //    this.pay = pay;
    //    this.satisfaction = satisfaction;
    //    this.giveTip = giveTip;
    //}
    //public override void Order()
    //{
    //    Init();
    //    Debug.Log("ConsumerSingle �ֹ�");
    //    string orderedPizza = pizzaManager.GetPizzaList(orderIdx).pizzaName;
    //    Debug.Log(orderedPizza);
    //}
}

