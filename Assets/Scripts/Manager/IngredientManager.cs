using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    #region Singletone
    private static IngredientManager instance;

    public static IngredientManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@IngredientManager");
            instance = go.AddComponent<IngredientManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }

    #endregion

    public Dictionary<string, ToppingsData> ingredientsData = new Dictionary<string, ToppingsData>();

    private void Awake()
    {
        InitIngredientsData();
    }

    void InitIngredientsData()
    {
        ToppingsData dow = new Dow();
        ToppingsData sauce = new Sauce();
        ToppingsData cheese = new Cheese();
        ToppingsData pepperoni = new Pepperoni();
        ToppingsData bacon = new Bacon();
        ToppingsData potato = new Potato();
        ToppingsData pineapple = new Pineapple();
        ToppingsData olive = new Olive();
        ToppingsData mushroom = new Mushroom();
        ToppingsData pepper = new Pepper();
        ToppingsData Corn = new Corn();

        ingredientsData.Add(dow.Name, dow);
        ingredientsData.Add(sauce.Name, sauce);
        ingredientsData.Add(cheese.Name, cheese);
        ingredientsData.Add(pepperoni.Name, pepperoni);
        ingredientsData.Add(bacon.Name, bacon);
        ingredientsData.Add(potato.Name, potato);
        ingredientsData.Add(pineapple.Name, pineapple);
        ingredientsData.Add(olive.Name, olive);
        ingredientsData.Add(mushroom.Name, mushroom);
        ingredientsData.Add(pepper.Name, pepper);
        ingredientsData.Add(Corn.Name, Corn);
    }

}