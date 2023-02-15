using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// ���� �ؾ��� ���� ���Ժ��� �ٸ��� �������ִ� ���̴�

// �����Ϸ��� ��� �ؾ� �ұ�?
// 1. ������ �����Ͱ� �����ؾ� �Ѵ�. �׷��� ���ǰ� �ִ�
// 2. �����͸� ���̽����� ��ȯ�ϴ� �۾��� �� ���̴�
// 3. ���̽��� �ܺο� �����ϴ°� ������ ������.

// �ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ������ ���·� ��ȯ
// 3. �ҷ��� �����͸� ���

// �����͵��� �������� �������� Ŭ�������� �ʿ��ϴ�

public class PlayerData
{
    public string name;
    public int repute;
    public int money;
    public int customTruck;
}

public class DataManager : MonoBehaviour
{
    // �̱���
    public static DataManager instance;

    // nowPlayer �� ���̽����� �ٲ� ���̴�
    // int nowslot;���� �տ� �ۺ��� �־����� �̰͵� �ۺ��� �տ� �ִ´�
    public PlayerData nowPlayer = new PlayerData();

    // ������ ������ �̸��� save�� ���ش�
    // ��δ� ���� path�� nowSlot���� ���� �� �ִ�
    public string path;
    //string filename = "save";

    //Select ��ũ��Ʈ�� Slot �Լ����� ������ ���嵥���� �̸��� �׻� �ٸ��� ����Ƿ��� �̷��� �־���Ѵ�
    public int nowSlot;

    // �⺻���� �̱��� �����̴�
    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        // ������ �Ŵ����� ���� ���� �����ؾ� �ϱ� ������ DontDestroyOnLoad�� �־ �׻� �����ǵ��� �Ѵ�
        // ������Ʈ�� �ı����� �ʵ��� ���־���
        DontDestroyOnLoad(this.gameObject);
        #endregion

        // File.WriteAllText(,data); �ʿ� �־��� path�̴�
        // ����Ƽ���� � �÷������� ����� ����Ƽ�� �˾Ƽ� ������ �������ش�
        // ��� �ڿ� /�� �־��־�� ������ ���� �� �ȴ�
        // /�� save�� �־ Select ��ũ��Ʈ�� File.Exists();�� ��θ� �����ش�
        path = Application.persistentDataPath + "/save";
    }

    void Start()
    {
        // PlayerManager�� SetData()�� �������� ���� ����

        //string data = JsonUtility.ToJson(nowPlayer);

        // �츮�� ������ ������ ���̱� ������, WriteAllText�� �� ���̴�
        // �� ���Ƶ� � ���ڸ� ������ ���̶�� ���̴�
        // path + �����̸��� �� �־��־�� � �����̾����� �� �� �ִ�
        //File.WriteAllText(path + filename, data);

    }

    // ���� ������ �ʿ��� ������ �׻� ���־�� �ϱ� ������ ������ �������־�� �Ѵ�
    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer); // �����͸� ���̽����� �ٲٰ�
        // �����̸� �ڿ� nowslot.ToString()�� ���ڿ��� �����ָ� ������ ������ ������ �̸��� �ٸ��� ����ȴ�
        // �̷��� ������ ������ save0,save1,save2,.... �̷��� �����̸��� ����ȴ�
        File.WriteAllText(path + nowSlot.ToString(), data); // ��ο��� �������ش�
    }

    // ������ �ϴ� �Ÿ� �ҷ����� �͵� �־�� �Ѵ�
    public void LoadData()
    {
        // ���⿡�� ���Կ� ������ ������ �̸��� �ٸ��� ����� ���� �����;� �ϱ� ������ �ڿ� + nowSlot.ToString()�� ���ڿ��� �־��ش�
        string data = File.ReadAllText(path + nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data); // �ҷ��� �����Ͱ� nowPlayer�� ��������� �ȴ�

        // ���Կ� ���� ����Ǵ� �̸��� �ٲ��شٸ� ���� ���Ը��� �ٸ� �̸����� ����ǰ� ���� �ٸ��� ����ǰ� ���� �ٸ��� �ҷ��� �� �ִ� ���̴�
        // �޲��� ���ӿ��� ���̴� �ҷ����� ��ɰ� ���ٰ� �����ϸ� �ȴ�
        // �޲��� ���� - ������ ��
    }
}