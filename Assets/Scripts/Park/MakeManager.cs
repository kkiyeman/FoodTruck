using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class MakeManager : MonoBehaviour
{

    [SerializeField] Button btnReadyBake;
    [SerializeField] Button btnOrder;
    [SerializeField] Button btnServe;
    [SerializeField] Button btnStart;
    [SerializeField] TMP_Text txtOrder1;
    [SerializeField] TMP_Text txtOrder2;
    [SerializeField] TMP_Text txtScore;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] Button btnGameStart;
    [SerializeField] Quest[] orderList;
    [SerializeField] GameObject makingPool;
    public int curOrderCount = 0;
    public int curBurgerIdx;
    [SerializeField] XRRayInteractor leftController;
    [SerializeField] XRRayInteractor rightController;
    [SerializeField] GameObject leftHand;
    [SerializeField] Transform leftHandHoldPoint;
    [SerializeField] GameObject rightHand;
    [SerializeField] GameObject rightHandHoldPoint;
    [SerializeField] Image log;
    [SerializeField] Text txtLog;
    [SerializeField] MakingPizza makingpizza;
    [SerializeField] GameObject makingZone;
    [SerializeField] GameObject OvenZone;
    [SerializeField] BakedPizza bakingpizza;
    [SerializeField] BakedPizza holdingBakedBizza;
    [SerializeField] GameObject HoldingPizza;
    [SerializeField] GameObject[] HPIngredients;
    [SerializeField] Transform[] consumerPoints;
    Animator rightAnimator;
    Animator leftAnimator;
    Dictionary<string, GameObject> holdingIngredients = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> bakedPizza = new Dictionary<string, GameObject>();
    List<ToppingsData> AddedIngredients = new List<ToppingsData>();
    ConsumerManager consumermanager;
    IngredientManager ingredientmanager;

    public List<string> progress = new List<string>();

    public WaitForSecondsRealtime wait5sec = new WaitForSecondsRealtime(5);

    string holdingIng = "";
    bool isMaking;
    bool isingredientAdding;
    bool isingredientHolding;
    bool isStart;
    bool isHoldingPizza;
    bool isHoldingBakedPizza;

    private int curOrder = 0;
    private string curOrderPizza;


    // Start is called before the first frame update
    void Start()
    {
        rightAnimator = rightHand.GetComponent<Animator>();
        leftAnimator = leftHand.GetComponent<Animator>();
        consumermanager = ConsumerManager.GetInstance();
        ingredientmanager = IngredientManager.GetInstance();
        InitHoldingIngredients();
        SetButton();
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

    private Transform GetRanConsumerPoint()
    {
        int length = consumerPoints.Length;
        int ran = Random.Range(0, length);
        return consumerPoints[ran];
    }




    public IEnumerator InitQuest()
    {
        while (isStart)
        {
            yield return wait5sec;

            int ran = Random.Range(1, 11);
            if (ran > 3)
            {

            }
        }

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
        btnReadyBake.onClick.AddListener(OnClickFinishMaking);
        btnOrder.onClick.AddListener(Order);
        btnServe.onClick.AddListener(ServePizza);
        btnStart.onClick.AddListener(OnClickGameStart);
    }

    private void OnClickGameStart()
    {
        isMaking = true;
        isingredientAdding = true;
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
        if (!isMaking)
        {
            int _idx = idx;
            curBurgerIdx = _idx;
            isMaking = true;
        }
    }



    private int GetScore(Pizza pizza)
    {
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
                    Debug.Log($"Ʋ�� ��� {progress[i]}!!");
                }
                exist = false;

            }
            if (less > 0)
                Debug.Log("��ᰡ �����մϴ�!");
            int score = fullScore - (noIngredients * 10) - (less * 10);
            return score;
        }
        else
        {
            Debug.Log("��ᰡ �ʹ� �����ϴ�!");
            int overload = progress.Count - recipe;
            int score = fullScore - (overload * 10);
            return score;
        }


    }


    public void ChooseIngredientsRight()
    {
        
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && !isingredientHolding && isingredientAdding)
        {
            if (hit.collider.tag == "MakingZone")
                return;
            HoldIngredient(hit.collider.tag);
            holdingIng = hit.collider.tag;
            isingredientHolding = true;
            rightAnimator.SetBool("Hold", true);
        }
        
    }


    public void AddIngredientToMakingPizza()
    {
        if (isingredientHolding)
        {
            RaycastHit hit;
            if (rightController.TryGetCurrent3DRaycastHit(out hit) && isingredientAdding)
            {
                if (hit.collider.tag != "MakingZone")
                    return;
                else
                {
                    var curAdd = ingredientmanager.ingredientsData[holdingIng];
                    progress.Add(curAdd.Name);
                    UnHoldIngredient(curAdd.Name);
                    makingpizza.AddIngredient(curAdd.Name);
                    bakingpizza.AddIngredient(curAdd.Name);
                    holdingBakedBizza.AddIngredient(curAdd.Name);
                    for (int i = 0; i<HPIngredients.Length; i++)
                    {
                        if (HPIngredients[i].name == curAdd.Name)
                            HPIngredients[i].SetActive(true);
                    }
                }
                isingredientHolding = false;
                holdingIng = "";
            }
            rightAnimator.SetBool("Hold", false);
        }
    }

    private void OnClickFinishMaking()
    {
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
            HoldingPizza.SetActive(true);
        }

    }

    public void HoldBakedPizza()
    {
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && progress.Count > 0 && !isingredientAdding && !isHoldingPizza)
        {
            rightAnimator.SetBool("HoldPizza", true);
            bakingpizza.FinishMaking();
            holdingBakedBizza.gameObject.SetActive(true);
            isHoldingPizza = true;
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

    public void MakeZoneHoverEnter()
    {
        MeshRenderer meshRD = makingZone.GetComponent<MeshRenderer>();
        meshRD.material = Resources.Load<Material>("Practice/Mat/HoveMat");
    }

    public void MakeZoneHoverExit()
    {
        MeshRenderer meshRD = makingZone.GetComponent<MeshRenderer>();
        meshRD.material = Resources.Load<Material>("Practice/Mat/DefaultMat");
    }

    public void OvenHoverEnter()
    {
        MeshRenderer meshRD = OvenZone.GetComponent<MeshRenderer>();
        meshRD.material = Resources.Load<Material>("Practice/Mat/HoveMat");
    }

    public void OvenHoverExit()
    {
        MeshRenderer meshRD = OvenZone.GetComponent<MeshRenderer>();
        meshRD.material = Resources.Load<Material>("Practice/Mat/DefaultMat");
    }

    public void Order()
    {
        if (curOrder < 2)
        {
            ConsumerBase2 consumerData = ConsumerManager.GetInstance().GetRandomConsumer();
            GameObject go = ObjectPoolManager.GetInstance().GetConsumerAvatar(GetRanConsumerPoint());

            List<string> orderPizza = consumerData.Order();
            int orderPizzaCnt = consumerData.OrderPizzaCnt();
           
            UIManager.GetInstance().OpenUI("uiOrder");

            GameObject uiOrder = UIManager.GetInstance().SetUI("uiOrder");

            if (orderPizza.Count > 1)
            {
                txtOrder1.text = $"{orderPizza[0]} 1, \n{orderPizza[1]} 1";
            }
            else
                txtOrder1.text = $"{orderPizza[0]} {orderPizzaCnt}";

            curOrder++;
        }
        else
            Debug.Log("�ֹ��Ұ�");
    }

    //���� ����
    public void ServePizza()
    {
        ObjectPoolManager.GetInstance().ReturnToConsumerPool();
        curOrder--;
    }
}
