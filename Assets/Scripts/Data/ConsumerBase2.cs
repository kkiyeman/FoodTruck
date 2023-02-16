using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase2
{
    public List<string> orderPizzaTest;
    public List<float> orderPizzaPrice;
    public string order;
    public string orderPizzaName;
    public int orderPizzaCnt = 1;
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

    public virtual string Order()
    {
        return order;
    }

    public virtual float Pay()
    {
        return pay;
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
    //주문
    public override string Order()
    {
        Init();
        Debug.Log("ConsumerSingle 주문");

        this.orderPizzaTest = new List<string>();

        int rand = Random.Range(0, 4);
        this.orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

        orderPizzaTest.Add(orderPizzaName);
        
        Debug.Log($"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요");

        this.order = $"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요";
        this.pay = pizzaManager.GetPizzaList(rand).price;

        return order;
    }
    //결제
    public override float Pay()
    {
        Init();
        Debug.Log($"${pay} 결제");
        playerManager.player.money += pay;

        return pay;
    }
    //팁
    public override void GiveTip()
    {
        int rand = Random.Range(0, 10);
        if (rand < 4)
        {
            giveTip = true;
            if (giveTip == true)
            {
                playerManager.player.money += tip;
            }
            else
                return;
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
    //주문
    public override string Order()
    {
        Init();
        Debug.Log("ConsumerDouble 주문");

        this.orderPizzaTest = new List<string>();
        this.orderPizzaPrice = new List<float>();

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
            this.order = $"{orderPizzaTest[0]} 1판, \n{orderPizzaTest[1]} 1판 주세요.";
            this.pay = orderPizzaPrice[0] + orderPizzaPrice[1];
        }
        else
        {
            Debug.Log($"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요.");
            this.order = $"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요.";
            this.pay = orderPizzaPrice[0] * 2;
        }

        return order;
    }
    //결제
    public override float Pay()
    {
        Init();
        Debug.Log($"${pay} 결제");
        playerManager.player.money += pay;

        return pay;
    }
    //팁
    public override void GiveTip()
    {
        int rand = Random.Range(0, 10);
        if (rand < 6)
        {
            giveTip = true;
            if (giveTip == true)
            {
                playerManager.player.money += tip;
            }
            else
                return;
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
    public override string Order()
    {
        Init();
        Debug.Log("ConsumerCustom 주문");

        return order;
    }
}

