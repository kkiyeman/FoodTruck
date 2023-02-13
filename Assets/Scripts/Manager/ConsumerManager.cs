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



    public ConsumerBase[] consumerDatas = new ConsumerBase[]
    {
        new ConsumerSingle(0, false, 1),
        new ConsumerDouble(0, false, 1),
    };

    public object GetRandomConsumer()
    {
        int rand = Random.Range(0, consumerDatas.Length);
        return consumerDatas[rand];
    }

    public ConsumerBase consumerData;

    void Start()
    {
        
        int rand = Random.Range(0, consumerDatas.Length);
        consumerData = consumerDatas[rand];
        consumerData.Order();
    }

    void Update()
    {
        
    }

}
