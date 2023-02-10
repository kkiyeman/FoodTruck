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

    public ConsumerBase[] consumerSingleDatas = new ConsumerBase[]
    {
        new ConsumerSingle(0,0,0,false),
        new ConsumerSingle(1,0,0,false),
        new ConsumerSingle(2,0,0,false),
        new ConsumerSingle(3,0,0,false),
    };

    public ConsumerBase[] consumerDoubleDatas = new ConsumerBase[]
    {
        new ConsumerDouble(0,0,0,false),
        new ConsumerDouble(0,0,0,false)
    };

    public object GetRandomConsumer()
    {
        int rand = Random.Range(0, consumerSingleDatas.Length);

        return consumerSingleDatas[rand];
    }

    public ConsumerBase consumerData;

    void Start()
    {
        int rand = Random.Range(0, consumerSingleDatas.Length);
        consumerData = consumerSingleDatas[rand];
        consumerData.Order();
    }

    void Update()
    {
        
    }
}
