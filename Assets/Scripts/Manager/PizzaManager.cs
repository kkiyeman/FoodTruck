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
        //Debug.Log($"메뉴 : {pizzaList[0][3].pizzaName}, 가격 : {pizzaList[0][3].price}, 레시피 : {pizzaList[0][3].recipe}");
        //Recipecheck();
    }

    public void PizzaListSet()
    {
        pizzaList = new List<Pizza[]>();

        //피자 (이름 ,  가격 ,    레시피)
        pizzaList.Add(new Pizza[]
        {
            new Pizza("페퍼로니", 5.9f, new string[]{"도우","소스","치즈","페퍼로니"}),
            new Pizza("베이컨포테이토", 6.9f, new string[]{"도우","소스","치즈","베이컨","포테이토"}),
            new Pizza("하와이안", 6.9f, new string[]{"도우", "소스", "치즈","베이컨","파인애플"}),
            new Pizza("99에비뉴", 7.9f, new string[]{"도우", "소스", "치즈","올리브","버섯","페퍼로니"})
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
