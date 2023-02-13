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

    // �ڷ�ƾ�� �տ� IEnumerator�� �ۼ��ؾ� �Ѵ�. ���ϱ�?
    // IEnumerator�� ���� Ÿ���̴�
    // IEnumerator�� ������
    // IEnumerator = ����� = ������ �ż��� �ڵ������� ���ִ� ������ǰ = ī���͸� ���ִ� ��
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("play");
        operation.allowSceneActivation = false;

        // while�� �ݺ����̴�
        // �ε��� ������ isDone�� true�� �Ǳ� ������ ��� �ݺ��ϰ� �Ѵ�
        while (!operation.isDone)
        {

        }
    }
}
