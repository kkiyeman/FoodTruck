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

        //기본재료 리스트             (이름, 가격, 상점수량, 인벤수량, 세일여부)
        baseIngredientList.Add(new Ingredient("도우", 4, 20, 0, false));
        baseIngredientList.Add(new Ingredient("소스", 5, 20, 0, false));
        baseIngredientList.Add(new Ingredient("치즈", 6, 20, 0, false));
        baseIngredientList.Add(new Ingredient("콘", 3, 20, 0, false));

        //토핑재료 리스트             (이름, 가격, 상점수량, 인벤수량, 세일여부)
        toppingList.Add(new Ingredient("페퍼로니", 0.6f, 10, 0, false));
        toppingList.Add(new Ingredient("베이컨", 0.8f, 10, 0, false));
        toppingList.Add(new Ingredient("포테이토", 0.2f, 10, 0, false));
        toppingList.Add(new Ingredient("파인애플", 0.4f, 10, 0, false));
        toppingList.Add(new Ingredient("올리브", 0.4f, 10, 0, false));
        toppingList.Add(new Ingredient("버섯", 0.4f, 10, 0, false));
        toppingList.Add(new Ingredient("피망", 0.4f, 10, 0, false));
    }

    //기본재료
    public Ingredient GetBaseIngredientList(int baseIngredientIdx)
    {
        return baseIngredientList[baseIngredientIdx];
    }

    //토핑재료
    public Ingredient GetToppingList(int toppingIdx)
    {
        return toppingList[toppingIdx];
    }

    //확인용
    public void IngredientCheck()
    {
        Debug.Log("[[기본재료]]");
        for (int i = 0; i < baseIngredientList.Count; i++)
        {
            Debug.Log(baseIngredientList[i].name);
        }

        Debug.Log("[[토핑재료]]");
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
                Debug.Log($"[[세일상품]] : {baseIngredientList[i].name}, [[가격]] : {baseIngredientList[i].price}");
            }
        }

        for(int i = 0; i < toppingList.Count; i++)
        {
            if(toppingList[i].sale == true)
            {
                toppingList[i].price = toppingList[i].price * 0.8f;
                Debug.Log($"[[세일상품]] : {toppingList[i].name}, [[가격]] : {toppingList[i].price}");
            }
        }
    }
}