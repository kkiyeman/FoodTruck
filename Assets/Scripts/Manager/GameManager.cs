using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    #region Singletone
    private static GameManager instance;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    private void Awake()
    {
        instance = this;
        ToppingInvenAcount();
        BaseInvenAcount();
    }
    #endregion

    public List<int> _ToppingInvenAcount = new List<int>();
    public List<int> _BaseInvenAcount = new List<int>();


    void Start()
    {

    }

    public void ToppingInvenAcount()
    {
        _ToppingInvenAcount.Add(0);
        _ToppingInvenAcount.Add(0);
        _ToppingInvenAcount.Add(0);
        _ToppingInvenAcount.Add(0);
        _ToppingInvenAcount.Add(0);
        _ToppingInvenAcount.Add(0);
        _ToppingInvenAcount.Add(0);
    }

    public void BaseInvenAcount() 
    {
        _BaseInvenAcount.Add(0);
        _BaseInvenAcount.Add(0);
        _BaseInvenAcount.Add(0);
        _BaseInvenAcount.Add(0);
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }
}
