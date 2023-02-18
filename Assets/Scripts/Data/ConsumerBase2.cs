using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase2
{
    public List<string> orderPizzaTest {get; set;}
    public List<float> orderPizzaPrice {get; set;}

    public string orderPizzaName {get; set;}
    public int orderPizzaCnt {get; set;}
    public float pay {get; set;}
    public int satisfaction {get; set;}
    public bool giveTip {get; set;}
    public int tip {get; set;}

    public PizzaManager pizzaManager;
    public PlayerManager playerManager;

    public void Init()
    {
        pizzaManager = PizzaManager.GetInstance();
        playerManager = PlayerManager.GetInstance();
    }

    public virtual List<string> Order()
    {
        return orderPizzaTest;
    }

    public virtual int OrderPizzaCnt()
    {
        return orderPizzaCnt;
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
        this.orderPizzaCnt = 1;
    }
    //주문
    public override List<string> Order()
    {
        Init();
        Debug.Log("ConsumerSingle 주문");

        orderPizzaTest = new List<string>();

        int rand = Random.Range(0, 4);
        orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

        orderPizzaTest.Add(orderPizzaName);
        
        Debug.Log($"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요");

        pay = pizzaManager.GetPizzaList(rand).price;

        return orderPizzaTest;
    }
    public override int OrderPizzaCnt()
    {
        return orderPizzaCnt;
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
    public override List<string> Order()
    {
        Init();
        Debug.Log("ConsumerDouble 주문");

        orderPizzaTest = new List<string>();
        orderPizzaPrice = new List<float>();
        //orderPizzaCnt = 1;

        for(int i = 0; i < 2; i++)
        {
            string orderPizzaName;
            
            int rand = Random.Range(0, 4);

            orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

            if(orderPizzaTest.Contains(orderPizzaName))
            {
                orderPizzaPrice.Add(pizzaManager.GetPizzaList(rand).price);
                if (orderPizzaCnt < 2)
                {
                    orderPizzaCnt++;
                }
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
            pay = orderPizzaPrice[0] + orderPizzaPrice[1];
        }
        else
        {
            Debug.Log($"{orderPizzaTest[0]} {orderPizzaCnt}판 주세요.");
            pay = orderPizzaPrice[0] * 2;
        }

        return orderPizzaTest;
    }

    public override int OrderPizzaCnt()
    {
        return orderPizzaCnt;
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
    public override List<string> Order()
    {
        Init();
        Debug.Log("ConsumerCustom 주문");

        return orderPizzaTest;
    }
}

