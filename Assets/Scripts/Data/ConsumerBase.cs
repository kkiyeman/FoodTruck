using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase
{
    public Dictionary<string, int> orderPizzaTest;
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
        Debug.Log("ConsumerSingle 주문");

        string orderPizzaName;
        int rand = Random.Range(0, 4);

        orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

        this.orderPizzaTest = new Dictionary<string, int>();
        
        orderPizzaTest.Add(orderPizzaName, 1);
        
        
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
        Debug.Log("ConsumerDouble 주문");


        this.orderPizzaTest = new Dictionary<string, int>();
        
        for(int i = 0; i < 2; i++)
        {
            string orderPizzaName;
            int rand = Random.Range(0, 4);

            orderPizzaName = pizzaManager.GetPizzaList(rand).pizzaName;

            if(orderPizzaTest.ContainsKey(orderPizzaName))
            {
                orderPizzaTest[orderPizzaName]++;
            }
            else
            {
                orderPizzaTest.Add(orderPizzaName, 1);
            }
        }

        foreach (var pizza in orderPizzaTest)
        {
            Debug.Log($"{pizza.Key} {pizza.Value}판 주세요.");
        }
    }
}

//3판 주문 손님
public class ConsumerTriple : ConsumerBase
{

}

