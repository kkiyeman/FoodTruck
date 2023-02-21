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
    public DataManager dataManager;

    public GameManager creat;

    // ���Կ� �ִ� ������ �ٲ�� ���ش�. �迭�� ������ش�
    public TMP_Text[] slotText;

    // CreatCanvas���� �÷��̾��̸��� �� ���� ������ ���̴�
    public TMP_Text newPlayerName;

    bool[] savefile = new bool[3];

    void Start()
    {

        // ���Ժ��� ����� �����Ͱ� �����Ѵ��� �Ǵ�
        // �츮�� �����ߴ� ��θ� Ȯ���� ���߰ڴٴ� �Ǵ��� ����
        // File.Exists�� �ش� ������ ��ΰ� �����ϴ��� �ƴ��� bool������ Ȯ�����ش�
        // for������ ������ 0������ 2������ ���� �Ѵ�
        // �׸��� ���ڿ� �������� i�� ���ָ� �������� 3�� �߿��� �۵��ϵ��� �Ѵ�
        // bool���� �̿��ؼ� ������ �������� �Ǻ��Ѵ�
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("check : " + DataManager.instance.path + $"{i}");
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                // save bool�� �߿� 0���� true�� �νĵǰ� �Ѵ�
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();

                slotText[i * 3].text = DataManager.instance.nowPlayer.name;
                slotText[i * 3 + 1].text = DataManager.instance.nowPlayer.repute.ToString();
                slotText[i * 3 + 2].text = DataManager.instance.nowPlayer.money.ToString();
            }
            else
            {
                // �����ؽ�Ʈ i�� �����Ǿ� ���� �ʴ�. ���־���Ѵ�
                slotText[i * 3].text = "������ �����Ͱ� �����ϴ�.";
                slotText[i * 3 + 1].text = "������ �����Ͱ� �����ϴ�.";
                slotText[i * 3 + 2].text = "������ �����Ͱ� �����ϴ�.";
            }
        }
        DataManager.instance.DataClear();
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
        // �����Ͱ� �ֱ� ������ ������ �ҷ������� ���̰� 
        if (savefile[number])
        {

            DataManager.instance.LoadData();
            GoGame();
        }
        else
        {
            Creat();
        }

        // 2. ����� �����Ͱ� ���� �� -> �ҷ����⸦ �ؼ� ��������� �Ѿ�� �Ѵ�
        // ������ �Ŵ��� ��ũ��Ʈ�� �ִ� �ε嵥���� �Լ��� �����´�
        //DataManager.instance.LoadData();

        // ��ǲ�ʵ忡 �Էµ� �÷��̾������ ��� �����ؾ� �ϴ����� �߿��ϴ�
        // �׷��ٰ� Creat �Լ����� ���ָ� �ȵȴ�. Ȯ�ο� GoGame�Լ��� �־ ���Ӿ����� �Ѿ�� ������ ���װ� �߻�
        // ���� �ٲ� �ڿ� �÷��̾������ �����Ϸ��� �ϸ� �̸��� ������ ä�� ������ �� ���̱� ������ ���װ� �߻�
        //DataManager.instance.nowPlayer.name = newPlayerName.text;

    }

    // �÷��̾ �Է��ϴ� â�� �ߵ��� Ȱ��ȭ���ش�
    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }

    // ���� ��ư�� ��Ŭ�� ������� ������ �Ѿ�� �ϴ� ����̴�. ���� Slot�Լ��� �Բ��Ѵ�
    public void GoGame()
    {
        // ����� �����Ͱ� ���� �� �����ϴ� ��������, ���� �� �����ų ���̴� �տ� !�� ���δ�
        if (!savefile[DataManager.instance.nowSlot])
        {
            // ����� �����Ͱ� ���ٸ� ���ο� �̸��� ������� ����̴�
            DataManager.instance.nowPlayer.name = newPlayerName.text;
            // �׸��� �ٽ� �ѹ� �� ������ �ִ� ���� ���� ���̴�
            DataManager.instance.SaveData();
        }
        // 0=Start, 1=Garage ������
        SceneManager.LoadScene(1);
    }
}