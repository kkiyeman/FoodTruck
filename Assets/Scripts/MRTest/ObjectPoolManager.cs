using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
        #region Singletone
    private static ObjectPoolManager instance = null;

    public static ObjectPoolManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectPoolManager");
            instance = go.AddComponent<ObjectPoolManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    [SerializeField] 
    private GameObject objectPrefeb;
    Queue<GameObject> ObjectPool = new Queue<GameObject>();
    
    GameObject[] consumerPool;      //손님아바타 풀
    Queue<GameObject> orderConsumer = new Queue<GameObject>();  //사용된 손님 담을 큐
    GameObject parent;      //손님아바타풀의 부모객체
    List<int> selectedNum = new List<int>();    //사용되고 있는 아바타

    public void CreateConsumerPool()      //parent게임오브젝트(ConsumerPool)에 손님아바타 객체 넣어 풀 생성
    {
        parent = new GameObject();
        parent.name = "ConsumerPool";
        consumerPool = ObjectManager.GetInstance().GetConsumerAvarears();
        for(int i = 0; i < consumerPool.Length; i++)
        {
            consumerPool[i].gameObject.transform.SetParent(parent.transform);
        }
    }

    public GameObject GetConsumerAvatar(Transform _transform)       //손님아바타 풀에서 랜덤으로 가져오기
    {
        GameObject consumerAvatar = null;
        int rand = Random.Range(0,4);

        if(consumerPool == null)
            CreateConsumerPool();

        if(selectedNum.Count == 0)      //사용되고 있는 아바타 x
        {
            selectedNum.Add(rand);
            consumerAvatar = consumerPool[rand];
            orderConsumer.Enqueue(consumerAvatar);                  //큐에 담김
            consumerAvatar.gameObject.SetActive(true);              //켜주고
            consumerAvatar.gameObject.transform.SetParent(null);    //풀에서 꺼냄
            consumerAvatar.gameObject.transform.position = _transform.position;
            return consumerAvatar;
        }
        else if(selectedNum.Count > 0)      //사용되고 있는 아바타 o
        {
            if(selectedNum.Contains(rand))          
            {
                Debug.Log($"{rand}번째 아바타 사용중");
                while(selectedNum.Contains(rand) == true)
                {
                    rand = Random.Range(0,4);           //랜덤 중복이면 다시
                }
            }
            selectedNum.Add(rand);
            consumerAvatar = consumerPool[rand];
            orderConsumer.Enqueue(consumerAvatar);
            consumerAvatar.gameObject.SetActive(true);
            consumerAvatar.gameObject.transform.SetParent(null);
            return consumerAvatar;
        }
        return consumerAvatar;
    }

    public void ReturnToConsumerPool()          //손님아바타 풀로 돌려보내기
    {
        var obj = orderConsumer.Dequeue();
        obj.gameObject.transform.SetParent(parent.transform);
        obj.gameObject.SetActive(false);
        selectedNum.RemoveAt(0);
    }

    GameObject CreateObject()
    {
        GameObject newObj = Instantiate(objectPrefeb, instance.transform);
        newObj.gameObject.SetActive(false);

        return newObj;
    }
    GameObject GetObject()
    {
        if(ObjectPool.Count > 0)
        {
            GameObject objectInPool = ObjectPool.Dequeue();
            
            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.SetParent(null);
            return objectInPool;
        }
        else
        {
            GameObject objectInPool = CreateObject();

            objectInPool.gameObject.SetActive(true);
            objectInPool.transform.SetParent(null);
            return objectInPool;
        }
    }

    public void ReturnObjectToQueue(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);
        instance.ObjectPool.Enqueue(obj);
    }
}
