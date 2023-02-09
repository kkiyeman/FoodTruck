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
    }

    public void SetIngredientList()
    {
        baseIngredientList = new List<Ingredient>();
        toppingList = new List<Ingredient>();

        //�⺻��� ����Ʈ
        baseIngredientList.Add(new Ingredient("����", 1, 20));
        baseIngredientList.Add(new Ingredient("�ҽ�", 1, 20));
        baseIngredientList.Add(new Ingredient("ġ��", 1, 20));

        //������� ����Ʈ
        toppingList.Add(new Ingredient("���۷δ�", 1, 10));
        toppingList.Add(new Ingredient("������", 1, 10));
        toppingList.Add(new Ingredient("��������", 1, 5));
        toppingList.Add(new Ingredient("���ξ���", 1, 5));
        toppingList.Add(new Ingredient("�ø���", 1, 5));
        toppingList.Add(new Ingredient("����", 1, 5));

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
            Debug.Log(baseIngredientList[i].Name);
        }

        Debug.Log("[[�������]]");
        for (int i = 0; i < toppingList.Count; i++)
        {
            Debug.Log(toppingList[i].Name);
        }
    }
}