using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    #region Singletone
    private static IngredientManager instance;

    public static IngredientManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@IngredientManager");
            instance = go.AddComponent<IngredientManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }

    #endregion

    public List<Ingredient> baseIngredientList;
    public List<Ingredient> toppingList;

    private void Awake()
    {
        SetIngredientList();
        //IngredientCheck();
        //SaleDay();
    }

    public void SetIngredientList()
    {
        baseIngredientList = new List<Ingredient>();
        toppingList = new List<Ingredient>();

        //�⺻��� ����Ʈ             (�̸�, ����, ��������, �κ�����, ���Ͽ���)
        baseIngredientList.Add(new Ingredient("����", 4, 20, 0, false));
        baseIngredientList.Add(new Ingredient("�ҽ�", 5, 20, 0, false));
        baseIngredientList.Add(new Ingredient("ġ��", 6, 20, 0, false));
        baseIngredientList.Add(new Ingredient("��", 3, 20, 0, false));

        //������� ����Ʈ             (�̸�, ����, ��������, �κ�����, ���Ͽ���)
        toppingList.Add(new Ingredient("���۷δ�", 0.6f, 10, 0, false));
        toppingList.Add(new Ingredient("������", 0.8f, 10, 0, false));
        toppingList.Add(new Ingredient("��������", 0.2f, 10, 0, false));
        toppingList.Add(new Ingredient("���ξ���", 0.4f, 10, 0, false));
        toppingList.Add(new Ingredient("�ø���", 0.4f, 10, 0, false));
        toppingList.Add(new Ingredient("����", 0.4f, 10, 0, false));
        toppingList.Add(new Ingredient("�Ǹ�", 0.4f, 10, 0, false));
    }

    //�⺻���
    public Ingredient GetBaseIngredientList(int baseIngredientIdx)
    {
        return baseIngredientList[baseIngredientIdx];
    }

    //�������
    public Ingredient GetToppingList(int toppingIdx)
    {
        return toppingList[toppingIdx];
    }

    //Ȯ�ο�
    public void IngredientCheck()
    {
        Debug.Log("[[�⺻���]]");
        for (int i = 0; i < baseIngredientList.Count; i++)
        {
            Debug.Log(baseIngredientList[i].name);
        }

        Debug.Log("[[�������]]");
        for (int i = 0; i < toppingList.Count; i++)
        {
            Debug.Log(toppingList[i].name);
        }
    }

    public void SaleDay()
    {
        baseIngredientList[1].sale = true;
        toppingList[2].sale = true;


        for(int i = 0; i < baseIngredientList.Count; i++)
        {
            if (baseIngredientList[i].sale == true)
            {
                baseIngredientList[i].price = baseIngredientList[i].price * 0.8f;
                Debug.Log($"[[���ϻ�ǰ]] : {baseIngredientList[i].name}, [[����]] : {baseIngredientList[i].price}");
            }
        }

        for(int i = 0; i < toppingList.Count; i++)
        {
            if(toppingList[i].sale == true)
            {
                toppingList[i].price = toppingList[i].price * 0.8f;
                Debug.Log($"[[���ϻ�ǰ]] : {toppingList[i].name}, [[����]] : {toppingList[i].price}");
            }
        }
    }
}