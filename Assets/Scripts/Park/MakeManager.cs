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

    private void SetButton()
    {
        btnUpperBread.onClick.AddListener(OnClickSpawnUpperBread);
        btnLettuce.onClick.AddListener(OnClickSpawnLettuce);
        btnTomato.onClick.AddListener(OnClickSpawnTomato);
        btnCheese.onClick.AddListener(OnClickSpawnCheese);
        btnPatty.onClick.AddListener(OnClickSpawnPatty);
        btnLowerBread.onClick.AddListener(OnClickSpawnLowerBread);
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
