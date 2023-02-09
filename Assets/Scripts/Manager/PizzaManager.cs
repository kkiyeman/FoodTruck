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

    public int pizzaListIdx;

    public List<Pizza> pizzaList;

    private void Awake()
    {
        PizzaListSet();
        //Debug.Log(pizzaList[0].Length);
        //Debug.Log($"�޴� : {pizzaList[0][3].pizzaName}, ���� : {pizzaList[0][3].price}, ������ : {pizzaList[0][3].recipe}");
        //Recipecheck();
    }

    public void PizzaListSet()
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
    public void Recipecheck()
    {
        for (int i = 0; i < pizzaList.Count; i++)
        {
            Debug.Log(pizzaList[i].recipe.Length);
        }
    }


}
