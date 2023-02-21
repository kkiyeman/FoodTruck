using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    // 비어있는 슬롯 창을 눌렀을 때 뜨는 창을 뜻한다
    // 나는 이것을 New Game을 눌렀을 때 CreateCanvas가 뜨도록 해야하고
    // Load를 눌렀을 때, SelectCanvas가 뜨도록 해야한다
    public DataManager dataManager;

    public GameManager creat;

    // 슬롯에 있는 문구가 바뀌도록 해준다. 배열로 만들어준다
    public TMP_Text[] slotText;

    // CreatCanvas에서 플레이어이름을 쓴 것을 저장할 것이다
    public TMP_Text newPlayerName;

    bool[] savefile = new bool[3];

    void Start()
    {

        // 슬롯별로 저장된 데이터가 존재한는지 판단
        // 우리가 저장했던 경로를 확인해 봐야겠다는 판단이 난다
        // File.Exists는 해당 파일의 경로가 존재하는지 아닌지 bool값으로 확인해준다
        // for문으로 돌려서 0번부터 2번까지 돌게 한다
        // 그리고 문자열 보관으로 i를 써주면 저장파일 3개 중에서 작동하도록 한다
        // bool값을 이용해서 참인지 거짓인지 판별한다
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("check : " + DataManager.instance.path + $"{i}");
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                // save bool값 중에 0번은 true로 인식되게 한다
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();

                slotText[i * 3].text = DataManager.instance.nowPlayer.name;
                slotText[i * 3 + 1].text = DataManager.instance.nowPlayer.repute.ToString();
                slotText[i * 3 + 2].text = DataManager.instance.nowPlayer.money.ToString();
            }
            else
            {
                // 슬롯텍스트 i가 지정되어 있지 않다. 해주어야한다
                slotText[i * 3].text = "저장한 데이터가 없습니다.";
                slotText[i * 3 + 1].text = "저장한 데이터가 없습니다.";
                slotText[i * 3 + 2].text = "저장한 데이터가 없습니다.";
            }
        }
        DataManager.instance.DataClear();
    }

    void Update()
    {

    }

    // 슬롯에 들어갈 함수이다
    // 슬롯이 3개인데 어떻게 알맞게 불러오는가?
    // 우리는 데이터 매니저에서 파일이름을 save로 정해주었다
    // 하지만 파일마다 슬롯이름이 다르게 지정되어야 한다
    public void Slot(int number)
    {
        // 슬롯 버튼의 온클릭 기능으로 원하는 저장데이터 씬으로 넘어가도록 해주는 기능이다
        DataManager.instance.nowSlot = number;

        // 1. 저장된 데이터가 없을 때
        // 데이터가 있기 때문에 게임이 불러와지는 것이고 
        if (savefile[number])
        {

            DataManager.instance.LoadData();
            GoGame();
        }
        else
        {
            Creat();
        }

        // 2. 저장된 데이터가 있을 때 -> 불러오기를 해서 차고씬으로 넘어가야 한다
        // 데이터 매니저 스크립트에 있던 로드데이터 함수를 가져온다
        //DataManager.instance.LoadData();

        // 인풋필드에 입력된 플레이어네임을 어디에 저장해야 하는지가 중요하다
        // 그렇다고 Creat 함수에서 해주면 안된다. 확인에 GoGame함수를 넣어서 게임씬으로 넘어가기 때문에 버그가 발생
        // 씬이 바뀐 뒤에 플레이어네임을 저장하려고 하면 이름이 없어진 채로 저장이 된 것이기 때문에 버그가 발생
        //DataManager.instance.nowPlayer.name = newPlayerName.text;

    }

    // 플레이어를 입력하는 창이 뜨도록 활성화해준다
    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    // 슬롯 버튼의 온클릭 기능으로 씬으로 넘어가게 하는 기능이다. 위의 Slot함수와 함께한다
    public void GoGame()
    {
        // 저장된 데이터가 있을 때 실행하는 것이지만, 없을 때 실행시킬 것이니 앞에 !를 붙인다
        if (!savefile[DataManager.instance.nowSlot])
        {
            // 저장된 데이터가 없다면 새로운 이름을 덮어씌우라는 명령이다
            DataManager.instance.nowPlayer.name = newPlayerName.text;
            // 그리고 다시 한번 더 저장해 주는 것이 좋을 것이다
            DataManager.instance.SaveData();
        }
        // 0=Start, 1=Garage 씬순서
        SceneManager.LoadScene(1);
    }
}