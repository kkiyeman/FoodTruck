using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeManager : MonoBehaviour
{

    [SerializeField] Button btnUpperBread;
    [SerializeField] Button btnLettuce;
    [SerializeField] Button btnTomato;
    [SerializeField] Button btnCheese;
    [SerializeField] Button btnPatty;
    [SerializeField] Button btnLowerBread;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] Button btnGameStart;
    [SerializeField] Image questBox;

    public WaitForSecondsRealtime wait5sec = new WaitForSecondsRealtime(5);
    bool isStart;

    Vector3 defaultRotation = new Vector3(-90, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetQuest()
    {
        while(isStart)
        {
            yield return wait5sec;

            int ran = Random.Range(1, 11);
            if(ran>7)
            {
                int ranidx = Random.Range(1, 5);
                var ob = Resources.Load<GameObject>("Practice/quest");
                var go = Instantiate(ob);
                go.transform.SetParent(questBox.transform);
                var quest = go.GetComponent<Quest>();
                switch(ranidx)
                {
                    case 1:
                        quest.txtQuest.text = "햄버거";
                        break;
                    case 2:
                        quest.txtQuest.text = "치즈버거";
                        break;
                    case 3:
                        quest.txtQuest.text = "비건버거";
                        break;
                    case 4:
                        quest.txtQuest.text = "고기버거";
                        break;

                }
            }
        }

    }

    private void SetButton()
    {
        btnUpperBread.onClick.AddListener(OnClickSpawnUpperBread);
        btnLettuce.onClick.AddListener(OnClickSpawnLettuce);
        btnTomato.onClick.AddListener(OnClickSpawnTomato);
        btnCheese.onClick.AddListener(OnClickSpawnCheese);
        btnPatty.onClick.AddListener(OnClickSpawnPatty);
        btnLowerBread.onClick.AddListener(OnClickSpawnLowerBread);
        btnGameStart.onClick.AddListener(OnClickGameStart);
    }

    private void OnClickGameStart()
    {
        isStart = true;
        StartCoroutine(GetQuest());
    }
    private void OnClickSpawnUpperBread()
    {
        SpawnIngredients("UpperBread");
    }

    private void OnClickSpawnLettuce()
    {
        SpawnIngredients("Lettuce");
    }
    private void OnClickSpawnTomato()
    {
        SpawnIngredients("Tomato");
    }
    private void OnClickSpawnCheese()
    {
        SpawnIngredients("Cheese");
    }
    private void OnClickSpawnPatty()
    {
        SpawnIngredients("Patty");
    }
    private void OnClickSpawnLowerBread()
    {
        SpawnIngredients("LowerBread");
    }

    private void SpawnIngredients(string name)
    {
        var ob = Resources.Load($"Practice/{ name}");
        var go = (GameObject)Instantiate(ob);
        go.transform.localEulerAngles = defaultRotation;
        go.transform.position = SpawnPoint.position;
    }
}
