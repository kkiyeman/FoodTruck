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

    public List<BaseIngredientData> ingredients = new List<BaseIngredientData>();

    private void Awake()
    {

    }

    void InitIngredientsData()
    {
        
        
    }

}