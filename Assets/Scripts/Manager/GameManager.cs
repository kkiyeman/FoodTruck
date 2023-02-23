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
        TruckColorSave();
    }
    #endregion
    public int colorCustomCheck;
    public List<int> _ToppingInvenAcount = new List<int>();
    public List<int> _BaseInvenAcount = new List<int>();
    public List<bool> _TruckColor = new List<bool>();

    void Start()
    {

    }


    public void TruckColorSave()
    {
        _TruckColor.Add(true);
        _TruckColor.Add(false);
        _TruckColor.Add(false);
        _TruckColor.Add(false);
        _TruckColor.Add(false);
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
