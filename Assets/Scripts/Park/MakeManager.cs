using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


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
    [SerializeField] GameObject makingPool;
    public int curOrderCount = 0;
    public int curBurgerIdx;
    [SerializeField] XRRayInteractor leftController;
    [SerializeField] XRRayInteractor rightController;
    [SerializeField] XRBaseController leftHand;
    [SerializeField] XRBaseController rightHand;
    [SerializeField] Image log;
    [SerializeField] Text txtLog;

    

    public List<Hamburger> burgerList = new List<Hamburger>();
    public List<Ingredients> ingredientList = new List<Ingredients>();

    public List<string> progress = new List<string>();

    public WaitForSecondsRealtime wait5sec = new WaitForSecondsRealtime(5);
    bool isMaking;
    bool isStart;

    Vector3 defaultRotation = new Vector3(-90, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InitBurgerData();
        InitIngredientsData();
       // SetButton();
    }

    private void InitIngredientsData()
    {
        UpperBread upperbread = new UpperBread();
        Lettuce lettuce = new Lettuce();
        Tomato tomato = new Tomato();
        Cheese cheese = new Cheese();
        Patty patty = new Patty();
        LowerBread lowerbread = new LowerBread();

        ingredientList.Add(upperbread); 
        ingredientList.Add(lettuce);
        ingredientList.Add(tomato) ;
        ingredientList.Add(cheese);
        ingredientList.Add(patty);
        ingredientList.Add(lowerbread);
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

    public IEnumerator InitQuest()
    {
        while (isStart)
        {
            yield return wait5sec;

            int ran = Random.Range(1, 11);
            if (ran > 3)
            {
                if (curOrderCount < 1)
                    SetOrder();
            }
        }

    }

    private void SetButton()
    {
        btnGameStart.onClick.AddListener(OnClickGameStart);
        btnServe.onClick.AddListener(OnClickServe);
    }

    private void OnClickGameStart()
    {
        isStart = true;
        StartCoroutine(InitQuest());
    }

    
    private void OnClickServe()
    {
        StartCoroutine(LogOn($"{GetScore(burgerList[curBurgerIdx])}"));
        for(int i = 0; i<orderList.Length;i++)
        {
            if(orderList[i].txtQuest.text == burgerList[curBurgerIdx].Name)
            {
                orderList[i].txtQuest.text = "";
                orderList[i].GetComponent<Button>().onClick.RemoveAllListeners();
                orderList[i].gameObject.SetActive(false);
            }
        }
        curOrderCount--;
        isMaking = false;
        for(int i = 0; i< makingPool.transform.childCount; i++)
        {
            Destroy(makingPool.transform.GetChild(i).gameObject);
        }
        curBurgerIdx = 0;
        progress.Clear();

    }
    
    private void OnClickOrderList(int idx)
    {
        if(!isMaking)
        {
            int _idx = idx;
            curBurgerIdx = _idx;
            isMaking = true;
        }
    }
    private void SetOrder()
    {
        int ran = Random.Range(0, 4 );
        var curBurger = burgerList[ran];
        if (curOrderCount == 0)
        {
            orderList[0].txtQuest.text = curBurger.Name;
            orderList[0].gameObject.SetActive(true);
            orderList[0].GetComponent<Button>().onClick.AddListener(() => {OnClickOrderList(ran);});
            curOrderCount++;
        }
        else
        {   
            orderList[1].txtQuest.text = curBurger.Name;
            orderList[1].gameObject.SetActive(true);
            orderList[1].GetComponent<Button>().onClick.AddListener(() => { OnClickOrderList(ran); });
            curOrderCount++;
        }

    }


    private void SpawnIngredients(string name)
    {
        var burger = burgerList[curBurgerIdx];
        var ob = Resources.Load($"Practice/{name}");
        var go = (GameObject)Instantiate(ob);
        go.transform.SetParent(makingPool.transform);
        go.transform.localEulerAngles = defaultRotation;
        go.transform.position = SpawnPoint.position;
        progress.Add(name);
    }

    private int GetScore(Hamburger hamburger)
    {
        int fullScore = 100;
        int recipe = hamburger.Recipe.Length;
        if (progress.Count<= recipe)
        {
            int less = recipe - progress.Count;
            bool exist = false;
            int noIngredients = 0;
            for (int i = 0; i < progress.Count; i++)
            {
                for(int j = 0; j<recipe;j++)
                {
                    if (progress[i] == hamburger.Recipe[j])
                        exist = true;       
                }
                if(!exist)
                {
                    noIngredients++;
                    Debug.Log($"틀린 재료 {progress[i]}!!");
                }
                exist = false;

            }
            if (less > 0)
                Debug.Log("재료가 부족합니다!");
            int score = fullScore - (noIngredients * 10) - (less*10);
            return score;
        }
        else
        {
            Debug.Log("재료가 너무 많습니다!");
            int overload = progress.Count - recipe;
            int score = fullScore - (overload * 10);
            return score;
        }


    }

    
    public void ChooseIngredientsRight()
    {
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && isMaking)
        {
            if (hit.collider.tag == "Untagged")
                return;
            SpawnIngredients(hit.collider.tag);
        }
        Animator handAnim = rightHand.model.GetComponent<Animator>();
        handAnim.SetBool("Hold", true);
    }

    public void LeftHandClick()
    {
        Animator handAnim = leftHand.model.GetComponent<Animator>();
        handAnim.SetTrigger("Click");
    }

    public IEnumerator LogOn(string info)
    {
        log.gameObject.SetActive(true);
        txtLog.text = info;
        yield return new WaitForSecondsRealtime(2f);
        log.gameObject.SetActive(false);
    }

    
}
