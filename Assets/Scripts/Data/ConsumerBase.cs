using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerBase
{
    public Pizza[] orderPizza;
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

//1판 주문 손님
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
        //int i = Random.Range(0, 4);
        this.orderPizza = pizzaManager.GetRandomPizza(1);

        //Pizza orderPizza = pizzaManager.GetPizzaList(i);
        Debug.Log($"{orderPizza} 1판 주세요");
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

        //int i = Random.Range(0, 4);
        this.orderPizza = pizzaManager.GetRandomPizza(2);


        //Pizza orderPizza = pizzaManager.GetPizzaList(i);
        //Debug.Log($"{orderPizza} 1판 주세요");

        //Pizza orderPizza1st;
        //Pizza orderPizza2nd;
        ////Pizza[] pizzaArray = new Pizza[2];
        ////float pay;

        ////for(int i = 0; i < pizzaArray.Length; i++)
        ////{
        ////    int rand = Random.Range(0, pizzaManager.pizzaList.Count);
        ////    int min = rand;

        ////    for(int x = 0; x < pizzaArray.Length; x++)
        ////    {
        ////        pizzaArray[i] = pizzaManager.pizzaList[rand];
        ////    }
        ////}

        ////Debug.Log($"{pizzaArray[0].pizzaName},{pizzaArray[1].pizzaName}");

        //orderPizza1st = pizzaManager.GetPizzaList(pizzaIdx1st);
        //orderPizza2nd = pizzaManager.GetPizzaList(pizzaIdx2nd);

        //pay = orderPizza1st.price + orderPizza2nd.price;

        //if(pizzaIdx1st == pizzaIdx2nd)
        //{
        //    string orderPizzaName = orderPizza1st.pizzaName;
        //    int orderPizzaCnt = 2;
        //    Debug.Log($"{orderPizzaName} {orderPizzaCnt}판 주세요.");
        //}

        //else
        //{
        //    if (pizzaIdx1st > pizzaIdx2nd)
        //    {
        //        int tmp = pizzaIdx1st;
        //        pizzaIdx1st = pizzaIdx2nd;
        //        pizzaIdx2nd = tmp;
        //        Debug.Log($"{orderPizza1st.pizzaName} 1판, {orderPizza2nd.pizzaName} 1판 주세요.");
        //    }
        //}
    }
}

//3판주문 손님
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
    //    Debug.Log("ConsumerSingle 주문");
    //    string orderedPizza = pizzaManager.GetPizzaList(orderIdx).pizzaName;
    //    Debug.Log(orderedPizza);
    //}
}

