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
    }
    
    public void SetPizzaList()
    {
        pizzaList = new List<Pizza>();

        pizzaList.Add(new Pizza("PepperoniPizza", 15, new string[] { "Dow", "Sauce", "Cheese", "Pepperoni" }));
        pizzaList.Add(new Pizza("BaconPotatoPizza", 17, new string[] { "Dow", "Sauce", "Cheese", "Bacon", "Potato" }));
        pizzaList.Add(new Pizza("HawaianPizza", 18, new string[] { "Dow", "Sauce", "Cheese", "Bacon", "Pineapple" }));
        pizzaList.Add(new Pizza("99Avenue", 20, new string[] { "Dow", "Sauce", "Cheese", "Mushroom","Pepper", "Pepperoni" }));

        pizzaCnt = pizzaList.Count;
    }

    public Pizza GetPizzaList(int pizzaListIdx)
    {
        return pizzaList[pizzaListIdx];
    }
    
}
