using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingPizza : MonoBehaviour
{

    [SerializeField] List<GameObject> Ingredients = new List<GameObject>();

    void Start()
    {
        
    }


    public void AddIngredient(string name)
    {
        for(int i = 0; i<Ingredients.Count; i++)
        {
            if (Ingredients[i].name == name)
                Ingredients[i].SetActive(true);
        }
    }

    public void FinishMaking()
    {
        for(int i = 0; i<Ingredients.Count; i++)
        {
            Ingredients[i].SetActive(false);
        }
    }
}
