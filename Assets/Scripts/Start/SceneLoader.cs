using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public Slider progressbar;
    // TextMesh Pro를 사용하기 위해서는 TMP_Text 라고 적어야 한다
    // 위에 using TMPro; 도 적어야 한다
    public TMP_Text loadtext;
    public static string loadScene;
    public static int loadType;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadSceneHandle(string _name, int _loadType)
    {
        loadScene = _name;
        loadType = _loadType;
        // 이것을 로딩씬으로 넘어가는 것이 아니라 로딩바캔버스만 등장하게 할 것이다
        SceneManager.LoadScene("Garage");
    }

    // 코루틴은 앞에 IEnumerator를 작성해야 한다. 왜일까?
    // IEnumerator은 리턴 타입이다
    // IEnumerator는 변수다
    // IEnumerator = 계수기 = 지폐의 매수를 자동적으로 세주는 전자제품 = 카운터를 세주는 것
    IEnumerator LoadScene()
    {
        // yield는 호출자에게 컬렉션 데이터를 하나씩 리턴할 때 사용한다
        // yield Return = 컬렌션 데이터를 하나씩 리턴하는데 사용
        // yield break = 리턴을 중지하고 iteration 루프를 빠져나올 때 사용
        // 처음에는 갖고 올 데이터가 없다는 뜻이다

        // AsyncOperation는 클래스이다
        // AsyncOperation는 비동기 전환을 이용할 수 있다
        // '비동기'는 동시에 일어나지 않는다는 뜻이다
        // 요청한 그 자리에서 결과가 주어지지 않는다
        // 결과가 주어지는데 시간이 걸리더라도 그 시간 동안 다른 작업을 할 수 있다. 그래서 효율적이다

        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);
        operation.allowSceneActivation = false;

        // while은 반복문이다
        // 로딩이 끝나서 isDone이 true가 되기 전까지 계속 반복하게 한다
        while (!operation.isDone)
        {
            yield return null;

            if (loadType == 0)
                Debug.Log("New Game");
            else if (loadType == 1)
                Debug.Log("not new Game");

            if (progressbar.value < 0.9f)
            {
                // Mathf는 소수점 처리를 뜻한다
                // Mathf에는 반올림, 올림, 내림 있다
                // Mathf.MoveTowards를 했다는 것은 현재 위치에서 목표 위치로 이동시킬 때 사용한다
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            
            if (progressbar.value >= 1f)
            {
                loadtext.text = "Press SpaceBar";
            }
            
            // 어떻게 하면 스페이스키 대신 컨트롤러의 키로 작동하도록 할 수 있을까?
            if (Input.GetKeyDown(KeyCode.Space) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}