using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class MakeManager : MonoBehaviour
{

    [SerializeField] Button btnReadyBake;
    [SerializeField] Button btnOrder;
    [SerializeField] Button btnServe;
    [SerializeField] Button btnStart;
    [SerializeField] Button btnRecipeOn;
    [SerializeField] Button btnRecipeOff;
    [SerializeField] Button btnReceiveOrder;
    [SerializeField] Button btnCloseShop;
    [SerializeField] Button btnReturnToShop;
    [SerializeField] GameObject noticeRecipe;
    [SerializeField] TMP_Text txtOrder1;
    [SerializeField] TMP_Text txtOrder2;
    [SerializeField] TMP_Text txtAmount1;
    [SerializeField] TMP_Text txtAmount2;
    [SerializeField] TMP_Text txtTotalCustomer;
    [SerializeField] TMP_Text txtTotalRevenue;
    [SerializeField] TMP_Text txtScore;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] Button btnGameStart;
    [SerializeField] Quest[] orderList;
    [SerializeField] GameObject makingPool;
    [SerializeField] XRRayInteractor leftController;
    [SerializeField] XRRayInteractor rightController;
    [SerializeField] GameObject leftHand;
    [SerializeField] Transform leftHandHoldPoint;
    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject rightHandHoldPoint;
    [SerializeField] Image log;
    [SerializeField] Text txtLog;
    [SerializeField] MakingPizza makingpizza;
    [SerializeField] GameObject serveZone;
    [SerializeField] GameObject OvenZone;
    [SerializeField] BakedPizza bakingpizza;
    [SerializeField] BakedPizza holdingBakedPizza;
    [SerializeField] GameObject HoldingPizza;
    [SerializeField] GameObject[] HPIngredients;
    [SerializeField] Transform[] consumerPoints;
    [SerializeField] GameObject OpenPizzabox;
    public GameObject ClosePizzabox;
    [SerializeField] GameObject PizzaBatchim;
    [SerializeField] GameObject Bell;
    [SerializeField] GameObject MakeZonePizBatchim;
    [SerializeField] GameObject Oven;
    [SerializeField] GameObject ovenFrame;
    [SerializeField] GameObject uiStart;
    [SerializeField] GameObject uiScore;
    [SerializeField] Text txtUiscore;

    [SerializeField] Text txtUserName;
    [SerializeField] Text txtDate;
    [SerializeField] Text txtPOSPizza1;
    [SerializeField] Text txtPOSPizza2;
    [SerializeField] Text txtPOSPizza3;
    [SerializeField] Text txtPOSPizza4;
    [SerializeField] Text txtPOSCount1;
    [SerializeField] Text txtPOSCount2;
    [SerializeField] Text txtPOSCount3;
    [SerializeField] Text txtPOSCount4;
    Vector3 formalBakePizzaPosition;
    public Vector3 formalPizzaBoxPosition;
    public Quaternion formalPizzaBoxRotation;
    Animator rightAnimator;
    Animator leftAnimator;
    Dictionary<string, GameObject> holdingIngredients = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> bakedPizza = new Dictionary<string, GameObject>();
    List<ToppingsData> AddedIngredients = new List<ToppingsData>();
    ConsumerManager consumermanager;
    IngredientManager ingredientmanager;

    public List<string> progress = new List<string>();

    public WaitForSecondsRealtime wait5sec = new WaitForSecondsRealtime(5);
    List<int> ranindex = new List<int>();

    AudioManager soundPlayer;

    string holdingIng = "";
    bool isMaking;
    bool isingredientAdding;
    bool isingredientHolding;
    bool isStart;
    bool isHoldingPizza;
    bool isHoldingBakedPizza;
    bool isboxOn;
    bool isOvenOpen;

    private int curOrder = 0;
    private string curOrderPizza1;
    private string curOrderPizza2;
    private int curScore;
    private float curRevenue;
    private int curCustomerNum;

    [SerializeField] 
    private List<XRSimpleInteractable> hoverInteractList = new List<XRSimpleInteractable>();

    // Start is called before the first frame update
    void Start()
    {
        curCustomerNum = 0;
        curScore = 0;
        curRevenue = 0;
        formalBakePizzaPosition = bakingpizza.transform.position;
        formalPizzaBoxPosition = ClosePizzabox.transform.position;
        formalPizzaBoxRotation = ClosePizzabox.transform.rotation;
        soundPlayer = AudioManager.GetInstance();
        soundPlayer.PlayBgm("Parkenvironment");
        rightAnimator = rightHand.GetComponent<Animator>();
        leftAnimator = leftHand.GetComponent<Animator>();
        consumermanager = ConsumerManager.GetInstance();
        ingredientmanager = IngredientManager.GetInstance();
        InitHoldingIngredients();
        SetButton();
        SetHoverGameObjects();
        SetRanidxQueue();
        SetUI();

    }

    private void Update()
    {
        RefreshUI();
    }

    private void SetUI()
    {
        if (DataManager.instance.nowPlayer.name == null)
            txtUserName.text = "textconfirm";
        else
            txtUserName.text = DataManager.instance.nowPlayer.name;


    }

    private void RefreshUI()
    {
        txtDate.text = DateTime.Now.ToString("yyyy" + "-" + "M" + "-" + "dd");
        txtTotalCustomer.text = $"Total Customer : {curCustomerNum}";
        txtTotalRevenue.text = $"Total Revenue : {curRevenue}.0$";
        if(curScore != 0&& curCustomerNum != 0)
        txtScore.text = $"Average Score : {curScore/curCustomerNum}";
        else
            txtScore.text = $"Average Score : 0";
    }

    private void SetRanidxQueue()
    {
        ranindex.Add(0);
        ranindex.Add(1);
        ranindex.Add(2);
        ranindex.Add(3);
    }

    public void OvenControl()
    {
        if(!isOvenOpen)
        {
            Animator ovenAnim = Oven.GetComponent<Animator>();
            ovenAnim.SetBool("isOpen", true);
            OvenZone.gameObject.SetActive(true);
            isOvenOpen = true;
        }
        else
        {
            Animator ovenAnim = Oven.GetComponent<Animator>();
            ovenAnim.SetBool("isOpen", false);
            OvenZone.gameObject.SetActive(false);
            isOvenOpen = false;
        }

    }
    private void InitHoldingIngredients()
    {
        var go = new GameObject();
        go.name = "@HoldingPool";
        go.transform.SetParent(rightHandHoldPoint.transform);
        var IngredeintsInfo = Resources.LoadAll<GameObject>("99Pizza/Holding");
        for (int i = 0; i < IngredeintsInfo.Length; i++)
        {
            var ingGo = Instantiate(IngredeintsInfo[i], go.transform);
            ingGo.transform.position = rightHandHoldPoint.transform.position;
            holdingIngredients.Add(ingGo.name, ingGo);
            ingGo.SetActive(false);
        }

    }

    private void SetHoverGameObjects()
    {
        for (int i = 0; i < hoverInteractList.Count; i++)
        {
            var curObj = hoverInteractList[i];
            curObj.hoverEntered.AddListener((e) => {
                HoverEnterMatChange(curObj.gameObject);
            });

            curObj.hoverExited.AddListener((e) => {
                HoverExitMatChange(curObj.gameObject);
            });
        }
    }

    private Transform GetRanConsumerPoint()
    {
        int ran = UnityEngine.Random.Range(0,3);
        int Ran = ranindex[ran];
        return consumerPoints[ran];
    }




    public IEnumerator InitOrder()
    {

        while (isStart)
        {
         yield return wait5sec;

         int ran = UnityEngine.Random.Range(1, 11);
         if (ran < 3)
         {
             Order();
         }
                
            
        }
    
    }

    public void StartDay()
    {
        if (!isStart)
        {
            uiStart.SetActive(false);
            Animator animator = Bell.GetComponent<Animator>();
            animator.SetTrigger("Ring");
            Invoke("BellRing", 0.01f);
            isStart = true;
            StartCoroutine(InitOrder());
        }
        else
            return;

    }

    private void BellRing()
    {
        soundPlayer.PlaySfx("BellRing");
    }
    private void HoldIngredient(string name)
    {
        holdingIngredients[$"Hold{name}(Clone)"].SetActive(true);
    }

    private void UnHoldIngredient(string name)
    {
        holdingIngredients[$"Hold{name}(Clone)"].SetActive(false);
    }

    private void SetButton()
    {

        btnStart.onClick.AddListener(OnClickMakeStart);
        btnRecipeOn.onClick.AddListener(OnClickRecipeOn);
        btnRecipeOff.onClick.AddListener(OnCilckRecipeOff);
        btnReceiveOrder.onClick.AddListener(OnClickReceiveOrder);
    }

    private void OnClickMakeStart()
    {
        if(!isMaking && !isHoldingPizza && !isingredientAdding)
        {
            isMaking = true;
            isingredientAdding = true;
            MakeZonePizBatchim.SetActive(true);
        }

        //StartCoroutine(InitQuest());
    }


    private void OnClickServe()
    {
        //StartCoroutine(LogOn($"{GetScore(burgerList[curBurgerIdx])}"));
        //for(int i = 0; i<orderList.Length;i++)
        //{
        //    if(orderList[i].txtQuest.text == burgerList[curBurgerIdx].Name)
        //    {
        //        orderList[i].txtQuest.text = "";
        //        orderList[i].GetComponent<Button>().onClick.RemoveAllListeners();
        //        orderList[i].gameObject.SetActive(false);
        //    }
        //}
        //curOrderCount--;
        //isMaking = false;
        //for(int i = 0; i< makingPool.transform.childCount; i++)
        //{
        //    Destroy(makingPool.transform.GetChild(i).gameObject);
        //}
        //curBurgerIdx = 0;
        //progress.Clear();

    }

    private void OnClickOrderList(int idx)
    {

    }



    private int GetScore(string pizzaname)
    {
        Pizza pizza = PizzaManager.GetInstance().GetPizzaByName(pizzaname);
        int fullScore = 100;
        int recipe = pizza.Recipe.Length;
        if (progress.Count <= recipe)
        {
            int less = recipe - progress.Count;
            bool exist = false;
            int noIngredients = 0;
            for (int i = 0; i < progress.Count; i++)
            {
                for (int j = 0; j < recipe; j++)
                {
                    if (progress[i] == pizza.Recipe[j])
                        exist = true;
                }
                if (!exist)
                {
                    noIngredients++;
                    Debug.Log($"틀린 재료 {progress[i]}!!");
                }
                exist = false;

            }
            if (less > 0)
                Debug.Log("재료가 부족합니다!");
            int score = fullScore - (noIngredients * 10) - (less * 10);
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
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && !isingredientHolding && isingredientAdding && hit.collider.tag != "MakingZone")
        {
            HoldIngredient(hit.collider.tag);
            holdingIng = hit.collider.tag;
            isingredientHolding = true;
            rightAnimator.SetBool("Hold", true);
        }
        else if(isingredientHolding)
        {
            if (rightController.TryGetCurrent3DRaycastHit(out hit) && isingredientAdding && hit.collider.tag == holdingIng)
            {
                UnHoldIngredient(holdingIng);
                holdingIng = "";
                soundPlayer.PlaySfx("Ingredient2");
                isingredientHolding = false;
                rightAnimator.SetBool("Hold", false);
            }
        }

        
    }


    public void AddIngredientToMakingPizza()
    {
        if (!isingredientHolding)
            return;

            RaycastHit hit;
            if (rightController.TryGetCurrent3DRaycastHit(out hit) && isingredientAdding && hit.collider.tag == "MakingZone")
            {

                    var curAdd = ingredientmanager.ingredientsData[holdingIng];
                    progress.Add(curAdd.Name);
                    UnHoldIngredient(curAdd.Name);
                    makingpizza.AddIngredient(curAdd.Name);
                    bakingpizza.AddIngredient(curAdd.Name);
                    holdingBakedPizza.AddIngredient(curAdd.Name);
                    for (int i = 0; i<HPIngredients.Length; i++)
                    {
                        if (HPIngredients[i].name == curAdd.Name)
                            HPIngredients[i].SetActive(true);
                    }
            if (holdingIng == "Dow")
                soundPlayer.PlaySfx("Dow");
            else
                soundPlayer.PlaySfx("Ingredient1");
                isingredientHolding = false;
                holdingIng = "";
                rightAnimator.SetBool("Hold", false);
            }
    }

    public void OnClickFinishMaking()
    {
        if(!isingredientHolding && isingredientAdding)
            isingredientAdding = false;
    }

    public void HoldPizza()
    {
        
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && progress.Count > 0 && !isingredientAdding && !isHoldingBakedPizza)
        {
            rightAnimator.SetBool("HoldPizza", true);
            isHoldingPizza = true;
            makingpizza.FinishMaking();
            MakeZonePizBatchim.SetActive(false);
            HoldingPizza.SetActive(true);
            PizzaBatchim.gameObject.SetActive(true);
        }

    }

    public void HoldBakedPizza()
    {
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && progress.Count > 0 && !isingredientAdding && !isHoldingPizza)
        {
            rightAnimator.SetBool("HoldPizza", true);
            bakingpizza.gameObject.SetActive(false);
            holdingBakedPizza.gameObject.SetActive(true);
            PizzaBatchim.gameObject.SetActive(true);
            isHoldingBakedPizza = true;
        }
         
    }

    public void BakePizza()
    {
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && progress.Count > 0  && isHoldingPizza && !isingredientAdding)
        {
            if (hit.collider.tag == "Oven")
            {
                for(int i = 0; i< HPIngredients.Length; i++)
                {
                    HPIngredients[i].SetActive(false);
                }
                rightAnimator.SetBool("HoldPizza", false);
                HoldingPizza.SetActive(false);
                PizzaBatchim.gameObject.SetActive(false);
                isHoldingPizza = false;
                Invoke("BakedPizzaOn", 3f);
            }
        }
    }

    private void BakedPizzaOn()
    {
        bakingpizza.gameObject.SetActive(true);
    }

    public void LeftHandClick()
    {
        leftAnimator.SetTrigger("Click");
    }

    public IEnumerator LogOn(string info)
    {
        log.gameObject.SetActive(true);
        txtLog.text = info;
        yield return new WaitForSecondsRealtime(2f);
        log.gameObject.SetActive(false);
    }

    public void HoverEnterMatChange(GameObject go)
    {
        MeshRenderer meshRD = go.GetComponent<MeshRenderer>();
        meshRD.material = Resources.Load<Material>("Practice/Mat/HoveMat");
    }

    public void HoverExitMatChange(GameObject go)
    {
        MeshRenderer meshRD = go.GetComponent<MeshRenderer>();
        meshRD.material = Resources.Load<Material>("Practice/Mat/DefaultMat");
    }

    public void OnSelectPizzabox()
    {
        if (isMaking && isHoldingBakedPizza)
        {
            OpenPizzabox.SetActive(true);
            serveZone.SetActive(true);
        }

    }
    public void OnSelectServingZone()
    {
        if(isHoldingBakedPizza)
        {
            holdingBakedPizza.FinishMaking();
            holdingBakedPizza.gameObject.SetActive(false);
            PizzaBatchim.gameObject.SetActive(false);

            bakingpizza.gameObject.SetActive(true);
            bakingpizza.transform.SetParent(null);
            bakingpizza.transform.position = ClosePizzabox.transform.position;
            isboxOn = true;
            isHoldingBakedPizza = false;
        }
        else if(!isHoldingBakedPizza && isMaking && progress.Count>0 && isboxOn)
        {
            OpenPizzabox.SetActive(false);
            serveZone.SetActive(false);
            bakingpizza.FinishMaking();
            bakingpizza.transform.SetParent(ovenFrame.transform);
            bakingpizza.transform.position = formalBakePizzaPosition;
            ClosePizzabox.SetActive(true);
            isboxOn = false;
        }
    }

    public void OnHoverBell()
    {
        if(!isStart)
        uiStart.SetActive(true);
    }

    public void OffHoverBell()
    {
        if(!isStart)
        uiStart.SetActive(false);
    }

    public void Order()
    {
        if (curOrder < 2)
        {
            ConsumerBase2 consumerData = ConsumerManager.GetInstance().GetRandomConsumer();
            GameObject go = ObjectPoolManager.GetInstance().GetConsumerAvatar();
            switch(go.name)
            {
                case "Avatar1(Clone)":
                    go.transform.position = consumerPoints[0].position;
                    soundPlayer.PlaySfx("Hellowoman1");
                    break;
                case "Avatar2(Clone)":
                    go.transform.position = consumerPoints[1].position;
                    soundPlayer.PlaySfx("Hellowoman2");
                    break;
                case "Avatar3(Clone)":
                    go.transform.position = consumerPoints[2].position;
                    soundPlayer.PlaySfx("HellowMan");
                    break;
                case "Avatar4(Clone)":
                    go.transform.position = consumerPoints[3].position;
                    soundPlayer.PlaySfx("HellowMan");
                    break;
            }

            List<string> orderPizza = consumerData.Order();
            int orderPizzaCnt = consumerData.OrderPizzaCnt();
            if(curOrder == 0)
            {
                if (orderPizza.Count > 1)
                {
                    curOrderPizza1 = orderPizza[0];
                    txtPOSPizza1.text = $"{orderPizza[0]}";
                    txtPOSPizza2.text = $"{orderPizza[1]}";
                    txtPOSCount1.text = "1";
                    txtPOSCount2.text = "1";
      
                }
                else
                {
                    curOrderPizza1 = orderPizza[0];
                    txtPOSPizza1.text = $"{orderPizza[0]}";
                    txtPOSPizza2.text = $"";
                    txtPOSCount1.text = "1";
                    txtPOSCount2.text = "";

                }


                
            }
            if(curOrder == 1)
            {
                if (orderPizza.Count > 1)
                {
                    txtPOSPizza3.text = $"{orderPizza[0]}";
                    txtPOSPizza4.text = $"{orderPizza[1]}";
                    txtPOSCount3.text = "1";
                    txtPOSCount4.text = "1";
                }
                else
                {
                    txtPOSPizza3.text = $"{orderPizza[0]}";
                    txtPOSPizza4.text = "";
                    txtPOSCount3.text = "1";
                    txtPOSCount4.text = "";
                }
              
            }



            curOrder++;



        }
        else
            Debug.Log("주문불가");
    }

    //피자 제공
    public void ServePizza()
    {
        ObjectPoolManager.GetInstance().ReturnToConsumerPool();
        isMaking = false;
        isingredientAdding = false;
        isingredientHolding = false;
        isHoldingPizza = false;
        isHoldingBakedPizza = false;
        isboxOn = false;
        progress.Clear();
        txtPOSPizza1.text = txtPOSPizza3.text;
        txtPOSCount1.text = txtPOSCount3.text;
        txtPOSPizza2.text = txtPOSPizza4.text;
        txtPOSCount2.text = txtPOSCount4.text;
        txtPOSPizza3.text = "";
        txtPOSPizza4.text = "";
        txtPOSCount3.text = "";
        txtPOSCount4.text = "";
        ClosePizzabox.transform.position = formalPizzaBoxPosition;
        ClosePizzabox.transform.rotation = formalPizzaBoxRotation;
        ClosePizzabox.SetActive(false);
        txtOrder1.gameObject.SetActive(false);
        txtAmount1.gameObject.SetActive(false);
        txtOrder2.gameObject.SetActive(false);
        txtAmount2.gameObject.SetActive(false);
        ShowScore(GetScore(curOrderPizza1));
        curScore += GetScore(curOrderPizza1);
        curCustomerNum++;
        curRevenue += PizzaManager.GetInstance().GetPizzaByName(curOrderPizza1).Price;
        curOrder--;
    }

    private void OnClickReceiveOrder()
    {
        txtOrder1.text = txtPOSPizza1.text;
        txtOrder2.text = txtPOSPizza2.text;
        txtAmount1.text = txtPOSCount1.text;
        txtAmount2.text = txtPOSCount2.text;
        txtOrder1.gameObject.SetActive(true);
        txtOrder2.gameObject.SetActive(true);
    }

    private void OnClickRecipeOn()
    {
        noticeRecipe.SetActive(true);
    }

    private void OnCilckRecipeOff()
    {
        noticeRecipe.SetActive(false);
    }

    public void ShowScore(int score)
    {
        txtUiscore.text = $"+{score}";
        uiScore.SetActive(true);
        Invoke("HideScore", 2f);
    }
    
    private void HideScore()
    {
        uiScore.SetActive(false);
    }

    private void OnClickCloseShop()
    {
        StopAllCoroutines();

    }

    private void OnClickReturn()
    {
        SceneManager.LoadScene("Garage");
    }
}
