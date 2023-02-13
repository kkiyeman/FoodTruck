using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    // 코루틴은 앞에 IEnumerator를 작성해야 한다. 왜일까?
    // IEnumerator은 리턴 타입이다
    // IEnumerator는 변수다
    // IEnumerator = 계수기 = 지폐의 매수를 자동적으로 세주는 전자제품 = 카운터를 세주는 것
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("play");
        operation.allowSceneActivation = false;

        // while은 반복문이다
        // 로딩이 끝나서 isDone이 true가 되기 전까지 계속 반복하게 한다
        while (!operation.isDone)
        {

        }
    }
}
