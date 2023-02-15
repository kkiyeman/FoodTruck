using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase2
{
    public List<string> orderPizzaTest;
    public List<float> orderPizzaPrice;
    public float pay;
    public int satisfaction;
    public bool giveTip;
    public int tip;

    public PizzaManager pizzaManager;
    public PlayerManager playerManager;

    public void Init()
    {
        pizzaManager = PizzaManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
    }

    public virtual void Order()
    {
        
    }

    public virtual void Pay()
    {

    }

    public virtual void GiveTip()
    {
        
    }
}

//1판 주문 손님
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
        this.orderPizzaTest = new List<string>();
        int rand = Random.Range(0, 4);

        orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;
        
        orderPizzaTest.Add(orderPizzaName);
        
        Debug.Log($"{orderPizzaName} 1판 주세요");

        this.pay = pizzaManager.GetPizzaList(rand).price;
    }

    public override void Pay()
    {
        Init();
        Debug.Log($"${pay} 결제");
        playerManager.player.money += pay;
    }

    public override void GiveTip()
    {
        if(giveTip == true)
        {
            playerManager.player.money += tip;
        }
    }
}

//2판 주문 손님
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
        this.orderPizzaPrice = new List<float>();
        int orderPizzaCnt = 1;

        for(int i = 0; i < 2; i++)
        {
            string orderPizzaName;
            
            int rand = Random.Range(0, 4);

            orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

            if(orderPizzaTest.Contains(orderPizzaName))
            {
                orderPizzaCnt++;
                orderPizzaPrice.Add(pizzaManager.GetPizzaList(rand).price);
            }
            else
            {
                orderPizzaTest.Add(orderPizzaName);
                orderPizzaPrice.Add(pizzaManager.GetPizzaList(rand).price);
                
            }
        }

        if(orderPizzaTest.Count > 1)
        {
            Debug.Log($"{orderPizzaTest[0]} 1판, {orderPizzaTest[1]} 1판 주세요.");
            this.pay = orderPizzaPrice[0] + orderPizzaPrice[1];
        }
        else
        {
            Debug.Log($"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요.");
            this.pay = orderPizzaPrice[0] * 2;
        }
    }

    public override void Pay()
    {
        Init();
        Debug.Log($"${pay} 결제");
        playerManager.player.money += pay;
    }

    public override void GiveTip()
    {
        if (giveTip == true)
        {
            playerManager.player.money += tip;
        }
    }
}

//3판 주문 손님
public class ConsumerCustom : ConsumerBase2
{
    public ConsumerCustom(int satisfaction, bool giveTip, int tip)
    {
        this.tip = tip;
        this.satisfaction = satisfaction;
        this.giveTip = giveTip;
    }
    public override void Order()
    {
        Init();
        Debug.Log("ConsumerCustom 주문");
    }
}

