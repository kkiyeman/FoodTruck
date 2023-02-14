using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerManager : MonoBehaviour
{
    #region Singletone
    private static ConsumerManager instance;

    public static ConsumerManager GetInstance()
    {
        if(instance == null)
        {
            GameObject go = new GameObject("@ConsumerManager");
            instance = go.AddComponent<ConsumerManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }

    #endregion



    public ConsumerBase2[] consumerDatas = new ConsumerBase2[]
    {
        new ConsumerSingle2(0, false, 1),
        new ConsumerDouble2(0, false, 1),
    };

    public object GetRandomConsumer()
    {
        int rand = Random.Range(0, consumerDatas.Length);
        return consumerDatas[rand];
    }

    public ConsumerBase2 consumerData;

    void Start()
    {
        //int rand = Random.Range(0, consumerDatas.Length);
        consumerData = consumerDatas[1];
        consumerData.Order();
    }

    void Update()
    {
        
    }

}
