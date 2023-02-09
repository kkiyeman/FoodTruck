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

        //기본재료 리스트
        baseIngredientList.Add(new Ingredient("도우", 1, 20));
        baseIngredientList.Add(new Ingredient("소스", 1, 20));
        baseIngredientList.Add(new Ingredient("치즈", 1, 20));

        //토핑재료 리스트
        toppingList.Add(new Ingredient("페퍼로니", 1, 10));
        toppingList.Add(new Ingredient("베이컨", 1, 10));
        toppingList.Add(new Ingredient("포테이토", 1, 5));
        toppingList.Add(new Ingredient("파인애플", 1, 5));
        toppingList.Add(new Ingredient("올리브", 1, 5));
        toppingList.Add(new Ingredient("버섯", 1, 5));

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
            Debug.Log(baseIngredientList[i].Name);
        }

        Debug.Log("[[토핑재료]]");
        for (int i = 0; i < toppingList.Count; i++)
        {
            Debug.Log(toppingList[i].Name);
        }
    }
}