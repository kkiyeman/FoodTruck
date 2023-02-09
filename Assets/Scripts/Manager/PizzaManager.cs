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

    public int pizzaListIdx = 0;

    public List<Pizza[]> pizzaList = new List<Pizza[]>();

    private void Awake()
    {
        PizzaListSet();
        //Debug.Log(pizzaList[0].Length);
        //Debug.Log($"�޴� : {pizzaList[0][3].pizzaName}, ���� : {pizzaList[0][3].price}, ������ : {pizzaList[0][3].recipe}");
        //Recipecheck();
    }

    public void PizzaListSet()
    {
        pizzaList = new List<Pizza[]>();

        //���� (�̸� ,  ���� ,    ������)
        pizzaList.Add(new Pizza[]
        {
            new Pizza("���۷δ�", 5.9f, new string[]{"����","�ҽ�","ġ��","���۷δ�"}),
            new Pizza("��������������", 6.9f, new string[]{"����","�ҽ�","ġ��","������","��������"}),
            new Pizza("�Ͽ��̾�", 6.9f, new string[]{"����", "�ҽ�", "ġ��","������","���ξ���"}),
            new Pizza("99����", 7.9f, new string[]{"����", "�ҽ�", "ġ��","�ø���","����","���۷δ�"})
        });
    }

    public void SetPizzaList(int pizzaList)
    {
        pizzaListIdx = pizzaList;
    }

    public Pizza[] GetPizzaList()
    {
        return pizzaList[pizzaListIdx];
    }

    public void Recipecheck()
    {
        for (int i = 0; i < pizzaList[0].Length; i++)
        {
            Debug.Log(pizzaList[0][i].recipe.Length);
        }
        
    }


}
