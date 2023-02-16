using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public Slider progressbar;
    // TextMesh Pro�� ����ϱ� ���ؼ��� TMP_Text ��� ����� �Ѵ�
    // ���� using TMPro; �� ����� �Ѵ�
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
        // �̰��� �ε������� �Ѿ�� ���� �ƴ϶� �ε���ĵ������ �����ϰ� �� ���̴�
        SceneManager.LoadScene("Garage");
    }

    // �ڷ�ƾ�� �տ� IEnumerator�� �ۼ��ؾ� �Ѵ�. ���ϱ�?
    // IEnumerator�� ���� Ÿ���̴�
    // IEnumerator�� ������
    // IEnumerator = ����� = ������ �ż��� �ڵ������� ���ִ� ������ǰ = ī���͸� ���ִ� ��
    IEnumerator LoadScene()
    {
        // yield�� ȣ���ڿ��� �÷��� �����͸� �ϳ��� ������ �� ����Ѵ�
        // yield Return = �÷��� �����͸� �ϳ��� �����ϴµ� ���
        // yield break = ������ �����ϰ� iteration ������ �������� �� ���
        // ó������ ���� �� �����Ͱ� ���ٴ� ���̴�

        // AsyncOperation�� Ŭ�����̴�
        // AsyncOperation�� �񵿱� ��ȯ�� �̿��� �� �ִ�
        // '�񵿱�'�� ���ÿ� �Ͼ�� �ʴ´ٴ� ���̴�
        // ��û�� �� �ڸ����� ����� �־����� �ʴ´�
        // ����� �־����µ� �ð��� �ɸ����� �� �ð� ���� �ٸ� �۾��� �� �� �ִ�. �׷��� ȿ�����̴�

        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);
        operation.allowSceneActivation = false;

        // while�� �ݺ����̴�
        // �ε��� ������ isDone�� true�� �Ǳ� ������ ��� �ݺ��ϰ� �Ѵ�
        while (!operation.isDone)
        {
            yield return null;

            if (loadType == 0)
                Debug.Log("New Game");
            else if (loadType == 1)
                Debug.Log("not new Game");

            if (progressbar.value < 0.9f)
            {
                // Mathf�� �Ҽ��� ó���� ���Ѵ�
                // Mathf���� �ݿø�, �ø�, ���� �ִ�
                // Mathf.MoveTowards�� �ߴٴ� ���� ���� ��ġ���� ��ǥ ��ġ�� �̵���ų �� ����Ѵ�
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
            
            // ��� �ϸ� �����̽�Ű ��� ��Ʈ�ѷ��� Ű�� �۵��ϵ��� �� �� ������?
            if (Input.GetKeyDown(KeyCode.Space) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}