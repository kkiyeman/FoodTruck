using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase2
{
    public List<string> orderPizzaTest;
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
public class ConsumerSingle2 : ConsumerBase2
{
    public ConsumerSingle2(int satisfaction, bool giveTip, int tip)
    {
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
        this.tip = tip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerSingle 주문");

        string orderPizzaName;
        int rand = Random.Range(0, 4);

        orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

        this.orderPizzaTest = new List<string>();
        
        orderPizzaTest.Add(orderPizzaName);
        
        
        Debug.Log($"{orderPizzaName} 1판 주세요");
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
public class ConsumerDouble2 : ConsumerBase2
{
    public ConsumerDouble2(int satisfaction, bool giveTip, int tip)
    {
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
        this.tip = tip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerDouble 주문");

        this.orderPizzaTest = new List<string>();
        int orderPizzaCnt = 1;

        for(int i = 0; i < 2; i++)
        {
            string orderPizzaName;
            int rand = Random.Range(0, 4);

            orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

            if(orderPizzaTest.Contains(orderPizzaName))
            {
                orderPizzaCnt++;
            }
            else
            {
                orderPizzaTest.Add(orderPizzaName);
            }
        }

        if(orderPizzaTest.Count > 1)
        {
            Debug.Log($"{orderPizzaTest[0]} 1판, {orderPizzaTest[1]} 1판 주세요.");
        }
        else
        {
            Debug.Log($"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요." );
        }
    }
}

//3판 주문 손님
public class ConsumerTriple2 : ConsumerBase2
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

