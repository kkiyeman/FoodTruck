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

        pizzaList.Add(new Pizza("Pepperoni", 15, new string[] { "도우", "소스", "치즈", "페퍼로니" }));
        pizzaList.Add(new Pizza("Bacon Potato", 17, new string[] { "도우", "소스", "치즈", "베이컨", "포테이토" }));
        pizzaList.Add(new Pizza("Hawaiian", 18, new string[] { "도우", "소스", "치즈", "베이컨", "파인애플" }));
        pizzaList.Add(new Pizza("99Avenue", 20, new string[] { "도우", "소스", "치즈", "버섯","피망", "페퍼로니" }));

        pizzaCnt = pizzaList.Count;
    }

    public Pizza GetPizzaList(int pizzaListIdx)
    {
        return pizzaList[pizzaListIdx];
    }
    
}
