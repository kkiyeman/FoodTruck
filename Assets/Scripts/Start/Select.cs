using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    // ����ִ� ���� â�� ������ �� �ߴ� â�� ���Ѵ�
    // ���� �̰��� New Game�� ������ �� CreateCanvas�� �ߵ��� �ؾ��ϰ�
    // Load�� ������ ��, SelectCanvas�� �ߵ��� �ؾ��Ѵ�
    public GameManager creat;

    // ���Կ� �ִ� ������ �ٲ�� ���ش�. �迭�� ������ش�
    public TMP_Text[] slotText;

    // CreatCanvas���� �÷��̾��̸��� �� ���� ������ ���̴�
    public TMP_Text newPlayerName;

    void Start()
    {
        // ���Ժ��� ����� �����Ͱ� �����Ѵ��� �Ǵ�
        // �츮�� �����ߴ� ��θ� Ȯ���� ���߰ڴٴ� �Ǵ��� ����
        // File.Exists�� �ش� ������ ��ΰ� �����ϴ��� �ƴ��� bool������ Ȯ�����ش� 
        if (File.Exists(DataManager.instance.path + null))
        {

        }

    }

    void Update()
    {

    }

    // ���Կ� �� �Լ��̴�
    // ������ 3���ε� ��� �˸°� �ҷ����°�?
    // �츮�� ������ �Ŵ������� �����̸��� save�� �����־���
    // ������ ���ϸ��� �����̸��� �ٸ��� �����Ǿ�� �Ѵ�
    public void Slot(int number)
    {
        // ���� ��ư�� ��Ŭ�� ������� ���ϴ� ���嵥���� ������ �Ѿ���� ���ִ� ����̴�
        DataManager.instance.nowSlot = number;

        // 1. ����� �����Ͱ� ���� ��
        Creat();

        // 2. ����� �����Ͱ� ���� �� -> �ҷ����⸦ �ؼ� ��������� �Ѿ�� �Ѵ�
        // ������ �Ŵ��� ��ũ��Ʈ�� �ִ� �ε嵥���� �Լ��� �����´�
        DataManager.instance.LoadData();

        // ��ǲ�ʵ忡 �Էµ� �÷��̾������ ��� �����ؾ� �ϴ����� �߿��ϴ�
        // �׷��ٰ� Creat �Լ����� ���ָ� �ȵȴ�. Ȯ�ο� GoGame�Լ��� �־ ���Ӿ����� �Ѿ�� ������ ���װ� �߻�
        // ���� �ٲ� �ڿ� �÷��̾������ �����Ϸ��� �ϸ� �̸��� ������ ä�� ������ �� ���̱� ������ ���װ� �߻�
        DataManager.instance.nowPlayer.name = newPlayerName.text;

        GoGame();
    }

    // �÷��̾ �Է��ϴ� â�� �ߵ��� Ȱ��ȭ���ش�
    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    // ���� ��ư�� ��Ŭ�� ������� ������ �Ѿ�� �ϴ� ����̴�. ���� Slot�Լ��� �Բ��Ѵ�
    public void GoGame()
    {
        SceneManager.LoadScene(1);
    }
}