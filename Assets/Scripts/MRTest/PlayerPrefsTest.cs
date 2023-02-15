using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsTest : MonoBehaviour
{
    public Player player1;
    public TestData testData1;

    public Text txtName;
    public Text txtReput;
    public Text txtMoney;

    public Button btnSave;

    public Text txtInt;
    public Text txtString;
    public Text txtFloat;
    public Button btnTest;

    public string TestKey = "testDataKey";

    int t2i = 0;
    float t3i = 0;

    private void Awake()
    {
        
    }
    public void SetData()
    {
        player1 = new Player("aaa", 0, 500);
        testData1 = new TestData(0, "테스트", 1.2f);
    }

    void Start()
    {
        LoadData();

        //txtName.text = player1.name;
        //t = PlayerPrefs.GetInt("TestCount", t);

        txtInt.text = $"{testData1.t}";
        txtString.text = testData1.t2;
        txtFloat.text = $"{testData1.t3}";

        txtReput.text = $"{PlayerPrefs.GetInt("playerRepute")}";
        txtMoney.text = $"{PlayerPrefs.GetInt("playerMoney")}";

        btnSave.onClick.AddListener(SaveData);
        btnTest.onClick.AddListener(Test1);
    }

    public void LoadData()
    {

        //string playerData = PlayerPrefs.GetString("player");
        //player1 = JsonUtility.FromJson<Player>(playerData);

        if (PlayerPrefs.HasKey(TestKey))
        {
            string TestDataJS = PlayerPrefs.GetString(TestKey);
            testData1 = JsonUtility.FromJson<TestData>(TestDataJS);
        }
        else
        {
            SetData();
        }

        //player1.name = PlayerPrefs.GetString("playerName");
        //player1.repute = PlayerPrefs.GetInt("playerRepute");
        //player1.money = PlayerPrefs.GetInt("playerMoney");
        //player1.customTruck = PlayerPrefs.GetInt("customTruck");
        //t = PlayerPrefs.GetInt("TestCount", t);

        Debug.Log("데이터 불러오기");
    }

    public void SaveData()
    {

        //string playerData = JsonUtility.ToJson(player1);
        //PlayerPrefs.SetString("player", playerData);

        string TestDataJS = JsonUtility.ToJson(testData1);
        PlayerPrefs.SetString(TestKey, TestDataJS);


        //PlayerPrefs.SetString("playerName", name);
        //PlayerPrefs.SetInt("playerRepute", 0);
        //PlayerPrefs.SetInt("playerMoney", 500);
        //PlayerPrefs.SetInt("customTruck", 1);

        //PlayerPrefs.SetInt("TestCount", t);

        Debug.Log("데이터 저장");
    }

    public void Test1()
    {
        testData1.t += 500;
        txtInt.text = $"{testData1.t}";
    }

    public void Test2()
    {
        t2i++;
        testData1.t2 = $"테스트{t2i}";
        txtString.text = testData1.t2;
    }

    public void Test3()
    {
        t3i++;
        testData1.t3 = testData1.t3 + t3i;
        txtFloat.text = $"{testData1.t3}";
    }
}