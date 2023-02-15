using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 이제 해야할 일은 슬롯별로 다르게 저장해주는 것이다

// 저장하려면 어떻게 해야 할까?
// 1. 저장할 데이터가 존재해야 한다. 그래야 의의가 있다
// 2. 데이터를 제이슨으로 변환하는 작업을 할 것이다
// 3. 제이슨을 외부에 저장하는게 마지막 순서다.

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터 형태로 변환
// 3. 불러온 데이터를 사용

// 데이터들을 전담으로 관리해줄 클래스들이 필요하다

public class PlayerData
{
    public string name;
    public int repute;
    public int money;
    public int customTruck;
}

public class DataManager : MonoBehaviour
{
    // 싱글톤
    public static DataManager instance;

    // nowPlayer 를 제이슨으로 바꿀 것이다
    // int nowslot;에도 앞에 퍼블릭을 넣었으니 이것도 퍼블릭을 앞에 넣는다
    public PlayerData nowPlayer = new PlayerData();

    // 저장할 파일을 이름을 save로 해준다
    // 경로는 이제 path와 nowSlot으로 해줄 수 있다
    public string path;
    //string filename = "save";

    //Select 스크립트의 Slot 함수에서 슬롯의 저장데이터 이름이 항상 다르게 저장되려면 이렇게 넣어야한다
    public int nowSlot;

    // 기본적이 싱글톤 설정이다
    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        // 데이터 매니저는 게임 내내 존재해야 하기 때문에 DontDestroyOnLoad을 넣어서 항상 유지되도록 한다
        // 오브젝트가 파괴되지 않도록 해주었다
        DontDestroyOnLoad(this.gameObject);
        #endregion

        // File.WriteAllText(,data); 쪽에 넣어줄 path이다
        // 유니티에서 어떤 플랫폼으로 만들든 유니티가 알아서 폴더를 생성해준다
        // 경로 뒤에 /를 넣어주어야 오류가 없이 잘 된다
        // /에 save를 넣어서 Select 스크립트의 File.Exists();의 경로를 정해준다
        path = Application.persistentDataPath + "/save";
    }

    void Start()
    {
        // PlayerManager의 SetData()를 가져오기 위해 쓴다

        //string data = JsonUtility.ToJson(nowPlayer);

        // 우리는 저장을 선택할 것이기 때문에, WriteAllText를 쓸 것이다
        // 딱 보아도 어떤 문자를 저장할 것이라는 뜻이다
        // path + 파일이름을 써 넣어주어야 어떤 파일이었는지 알 수 있다
        //File.WriteAllText(path + filename, data);

    }

    // 보통 저장은 필요할 때마다 항상 해주어야 하기 때문에 별도로 생성해주어야 한다
    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer); // 데이터를 제이슨으로 바꾸고
        // 파일이름 뒤에 nowslot.ToString()를 문자열로 더해주면 저장할 때마다 파일의 이름이 다르게 저장된다
        // 이러면 저장할 때마다 save0,save1,save2,.... 이렇게 파일이름이 저장된다
        File.WriteAllText(path + nowSlot.ToString(), data); // 경로에다 저장해준다
    }

    // 저장을 하는 거면 불러오는 것도 있어야 한다
    public void LoadData()
    {
        // 여기에도 슬롯에 데이터 파일의 이름이 다르게 저장된 것을 꺼내와야 하기 때문에 뒤에 + nowSlot.ToString()를 문자열로 넣어준다
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data); // 불러온 데이터가 nowPlayer에 덮어씌어지게 된다

        // 슬롯에 따라서 저장되는 이름을 바꿔준다면 각각 슬롯마다 다른 이름으로 저장되고 각각 다르게 저장되고 각각 다르게 불러올 수 있는 것이다
        // 쭈끄르 게임에서 쓰이는 불러오기 기능과 같다고 생각하면 된다
        // 쭈끄르 게임 - 마녀의 집
    }
}