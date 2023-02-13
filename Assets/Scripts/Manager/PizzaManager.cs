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
        //Debug.Log($"메뉴 : {pizzaList[3].pizzaName}, 가격 : {pizzaList[3].price}, 레시피 : {pizzaList[3].recipe}");
        //Recipecheck();
    }

    public void SetPizzaList()
    {
        pizzaList = new List<Pizza>();

        //                  피자 (이름 ,  가격 ,    레시피)

        pizzaList.Add(new Pizza("페퍼로니", 5.9f, new string[] { "도우", "소스", "치즈", "페퍼로니" }));
        pizzaList.Add(new Pizza("베이컨포테이토", 6.9f, new string[] { "도우", "소스", "치즈", "베이컨", "포테이토" }));
        pizzaList.Add(new Pizza("하와이안", 6.9f, new string[] { "도우", "소스", "치즈", "베이컨", "파인애플" }));
        pizzaList.Add(new Pizza("99에비뉴", 7.9f, new string[] { "도우", "소스", "치즈", "올리브", "버섯", "페퍼로니" }));
    }

    public Pizza GetPizzaList(int pizzaListIdx)
    {
        return pizzaList[pizzaListIdx];
    }
    
    //레시피 잘 들어갔는지 확인용
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
