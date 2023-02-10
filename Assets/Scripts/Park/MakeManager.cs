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
    [SerializeField] Button btnServe;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] Button btnGameStart;
    [SerializeField] Quest[] orderList;
    public int curOrderCount = 0;
    public string curMakingBurger = "";

    public List<Hamburger> burgerList = new List<Hamburger>();


    public WaitForSecondsRealtime wait5sec = new WaitForSecondsRealtime(5);
    bool isStart;

    Vector3 defaultRotation = new Vector3(-90, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InitBurgerData();
        SetButton();
    }

    private void InitBurgerData()
    {
        Burger burger = new Burger();
        CheeseBurger cheeseburger = new CheeseBurger();
        VeganBurger veganburger = new VeganBurger();
        MeetBurger meetburger = new MeetBurger();

        burgerList.Add(burger);
        burgerList.Add(cheeseburger);
        burgerList.Add(veganburger);
        burgerList.Add(meetburger);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator GetQuest()
    {
        while (isStart)
        {
            yield return wait5sec;

            int ran = Random.Range(1, 11);
            if (ran > 3)
            {
                if (curOrderCount < 2)
                    GetOrder();
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
        btnServe.onClick.AddListener(OnClickServe);
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
    
    private void OnClickServe()
    {

    }
    
    private void OnClickOrderList(int idx, string name)
    {
        curMakingBurger = name;


    }
    private void GetOrder()
    {
        int ran = Random.Range(1, 5);
        var curBurger = burgerList[ran];
        if(curOrderCount == 0)
        {
            int idx = ran;
            orderList[0].txtQuest.text = curBurger.Name;
            orderList[0].gameObject.SetActive(true);
            orderList[0].GetComponent<Button>().onClick.AddListener(() => {OnClickOrderList(idx,curBurger.Name);});
            curOrderCount++;
        }
        else
        {
            int idx = ran;
            orderList[1].txtQuest.text = curBurger.Name;
            orderList[1].gameObject.SetActive(true);
            orderList[1].GetComponent<Button>().onClick.AddListener(() => { OnClickOrderList(idx,curBurger.Name); });
            curOrderCount++;
        }

    }

    private void OrderProgress(int idx)
    {

    }
    private void SpawnIngredients(string name)
    {
        var ob = Resources.Load($"Practice/{ name}");
        var go = (GameObject)Instantiate(ob);
        go.transform.localEulerAngles = defaultRotation;
        go.transform.position = SpawnPoint.position;
    }
}
