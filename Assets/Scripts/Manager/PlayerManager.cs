using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singletone
    private static PlayerManager instance;

    public static PlayerManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@PlayerManager");
            instance = go.AddComponent<PlayerManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }

    #endregion

    public Player player;

    public string SaveKey = "PlayerDataSave";

    void Start()
    {
        LoadData();
    }

    public void SetData()
    {
        player = new Player("Player1", 0, 500, 1);
    }

    public void SaveData()
    {
        string PlayerData = JsonUtility.ToJson(player);
        PlayerPrefs.SetString(SaveKey, PlayerData);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string PlayerData = PlayerPrefs.GetString(SaveKey);
            player = JsonUtility.FromJson<Player>(PlayerData);
        }
        else
            SetData();
    }
}