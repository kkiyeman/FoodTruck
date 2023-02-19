using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class MakeManager : MonoBehaviour
{

   
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
    Dictionary<string, GameObject> holdingIngredients = new Dictionary<string, GameObject>();
    Dictionary<string, BaseIngredientData> AddedIngredients = new Dictionary<string, BaseIngredientData>();

  
    public List<string> progress = new List<string>();

    public WaitForSecondsRealtime wait5sec = new WaitForSecondsRealtime(5);
    bool isMaking;
    bool ingredientHolding;
    bool isStart;

    Vector3 defaultRotation = new Vector3(-90, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        isMaking = true;
        InitHoldingIngredients();
        // SetButton();
    }

    private void InitHoldingIngredients()
    {
        var go = new GameObject();
        go.name = "@HoldingPool";
        go.transform.SetParent(rightHandHoldPoint.transform);
        var IngredeintsInfo = Resources.LoadAll<GameObject>("99Pizza/Holding");
        for(int i = 0; i<IngredeintsInfo.Length; i++)
        {
            var ingGo = Instantiate(IngredeintsInfo[i], go.transform);
            ingGo.transform.position = rightHandHoldPoint.transform.position;
            holdingIngredients.Add(ingGo.name, ingGo);
            ingGo.SetActive(false);
        }
        
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

    private void HoldIngredient(string name)
    {
        holdingIngredients[$"Hold{name}(Clone)"].SetActive(true);
    }

    private void SetButton()
    {
        btnGameStart.onClick.AddListener(OnClickGameStart);
    }

    private void OnClickGameStart()
    {
        isStart = true;
        StartCoroutine(InitQuest());
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
        if(!isMaking)
        {
            int _idx = idx;
            curBurgerIdx = _idx;
            isMaking = true;
        }
    }
    private void SetOrder()
    {
        //int ran = Random.Range(0, 4 );
        //var curBurger = burgerList[ran];
        //if (curOrderCount == 0)
        //{
        //    orderList[0].txtQuest.text = curBurger.Name;
        //    orderList[0].gameObject.SetActive(true);
        //    orderList[0].GetComponent<Button>().onClick.AddListener(() => {OnClickOrderList(ran);});
        //    curOrderCount++;
        //}
        //else
        //{   
        //    orderList[1].txtQuest.text = curBurger.Name;
        //    orderList[1].gameObject.SetActive(true);
        //    orderList[1].GetComponent<Button>().onClick.AddListener(() => { OnClickOrderList(ran); });
        //    curOrderCount++;
        //}

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
        ingredientHolding = true;
        RaycastHit hit;
        if (rightController.TryGetCurrent3DRaycastHit(out hit) && isMaking)
        {
            HoldIngredient(hit.collider.tag);
        }
        Animator handAnim = rightHand.GetComponent<Animator>();
        handAnim.SetBool("Hold", true);
    }

    public void AddIngredientToMakingPizza()
    {
        if(ingredientHolding)
        {
            RaycastHit hit;
            if(rightController.TryGetCurrent3DRaycastHit(out hit) && isMaking)
            {

            }
            Animator handAnim = rightHand.GetComponent<Animator>();
            handAnim.SetBool("Hold", false);
        }
    }

    public void LeftHandClick()
    {
        Animator handAnim = leftHand.GetComponent<Animator>();
        handAnim.SetTrigger("Click");
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
    
}
