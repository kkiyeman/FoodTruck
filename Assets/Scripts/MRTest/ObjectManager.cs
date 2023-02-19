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
    GameObject[] consumerAvatars;
    
    // public GameObject CreateConsumer()      //안씀
    // {
    //     int rand = Random.Range(1, 5);
    //     Debug.Log($"{rand}");
    //     string avatarName = $"Avatar{rand}";
    //     Object consumerObj = Resources.Load("Models/Avatar/"+avatarName);
    //     GameObject consumerAvatar = (GameObject)Instantiate(consumerObj);

    //     return consumerAvatar;
    // }

    public void CreateConsumerAvatars()     //손님아바타 배열 생성
    {
        consumerAvatars = new GameObject[4];

        for(int i = 0; i < 4; i++)
        {
            string avatarName = $"Avatar{i+1}";
            Object consumerObj = Resources.Load("Models/Avatar/"+avatarName);
            GameObject consumerAvatar = (GameObject)Instantiate(consumerObj);
            consumerAvatar.gameObject.SetActive(false);

            consumerAvatars[i] = consumerAvatar;
        }
    }

    public GameObject[] GetConsumerAvarears()   //생성한 손님아바타 배열 내보내기
    {
        CreateConsumerAvatars();
        return consumerAvatars;
    }
}
