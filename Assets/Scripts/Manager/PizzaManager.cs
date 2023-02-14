using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PizzaManager : MonoBehaviour
{
    #region Singletone
    private static PizzaManager instance;

    public static PizzaManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@PizzaManager");
            instance = go.AddComponent<PizzaManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }

    #endregion

    public List<Pizza> pizzaList;
    public int pizzaCnt;

    private void Awake()
    {
        SetPizzaList();
        //Debug.Log(pizzaList.Count);
        //Debug.Log($"�޴� : {pizzaList[3].pizzaName}, ���� : {pizzaList[3].price}, ������ : {pizzaList[3].recipe}");
        //Recipecheck();
    }

    public void SetPizzaList()
    {
        pizzaList = new List<Pizza>();

        //                  ���� (�̸� ,  ���� ,    ������)

        pizzaList.Add(new Pizza("페퍼로니", 5.9f, new string[] { "����", "�ҽ�", "ġ��", "���۷δ�" }));
        pizzaList.Add(new Pizza("베이컨포테이토", 6.9f, new string[] { "����", "�ҽ�", "ġ��", "������", "��������" }));
        pizzaList.Add(new Pizza("하와이안", 6.9f, new string[] { "����", "�ҽ�", "ġ��", "������", "���ξ���" }));
        pizzaList.Add(new Pizza("99에비뉴", 7.9f, new string[] { "����", "�ҽ�", "ġ��", "�ø���", "����", "���۷δ�" }));

        pizzaCnt = pizzaList.Count;
    }

    public Pizza GetPizzaList(int pizzaListIdx)
    {
        return pizzaList[pizzaListIdx];
    }
    
    //������ �� ������ Ȯ�ο�
    public void Recipecheck(int i)
    {
        //for (int i = 0; i < pizzaList.Count; i++)
        //{
        //    Debug.Log(pizzaList[i].recipe.Length);
        //}
        Debug.Log(pizzaList[i].recipe.Length);
    }

    //public void GetRandomPizza(int PizzaCnt)
    //{
    //    int rand;

    //    for (int i = 0; i < PizzaCnt; i++)
    //    {
    //        rand = Random.Range(0, 3);
    //        string orderPizzaName = pizzaList[rand].pizzaName;
    //        Debug.Log(orderPizzaName);
    //    }
    //}
    

//랜덤피자 배열로 전달
    // public Pizza[] GetRandomPizza(int PizzaCnt)
    // {
    //     int rand;
    //     int pizzaArrayCnt = 0;
    //     Pizza[] pizzaArray = new Pizza[PizzaCnt];
    //     Pizza pizza;

    //     for (int i = 0; i < PizzaCnt; i++)
    //     {
    //         rand = Random.Range(0, 4);
    //         pizzaArray[i] = pizzaList[rand];
    //         pizzaArrayCnt++;
    //     }

    //     pizzaArray = pizzaArray.OrderBy(data => pizzaList.IndexOf(data)).ToArray();

    //     for (int i = 0; i < pizzaArray.Length; i++)
    //     {
    //         Debug.Log($"{pizzaArray[i].pizzaName} {pizzaArrayCnt}판 주세요.");
    //     }

    //     return pizzaArray;
    // }
}
