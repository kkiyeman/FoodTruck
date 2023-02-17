using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    public GameObject CreateConsumer()
    {
        int rand = Random.Range(1, 5);
        Debug.Log($"{rand}");
        string avatarName = $"Avatar{rand}";
        Object consumerObj = Resources.Load("Models/Avatar/"+avatarName);
        GameObject consumerAvatar = (GameObject)Instantiate(consumerObj);

        return consumerAvatar;
    }

}
