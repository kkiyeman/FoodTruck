using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        pizzaList.Add(new Pizza("���۷δ�", 5.9f, new string[] { "����", "�ҽ�", "ġ��", "���۷δ�" }));
        pizzaList.Add(new Pizza("��������������", 6.9f, new string[] { "����", "�ҽ�", "ġ��", "������", "��������" }));
        pizzaList.Add(new Pizza("�Ͽ��̾�", 6.9f, new string[] { "����", "�ҽ�", "ġ��", "������", "���ξ���" }));
        pizzaList.Add(new Pizza("99����", 7.9f, new string[] { "����", "�ҽ�", "ġ��", "�ø���", "����", "���۷δ�" }));
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

    public void GetRandomPizza(int PizzaCnt)
    {
        int rand;
        Pizza[] pizzaArray = new Pizza[PizzaCnt];

        for (int i = 0; i < PizzaCnt; i++)
        {
            rand = Random.Range(0, 3);
            pizzaArray[i] = pizzaList[rand];
            string orderPizzaName = pizzaList[rand].pizzaName;
            Debug.Log(orderPizzaName);
        }
    }
}
