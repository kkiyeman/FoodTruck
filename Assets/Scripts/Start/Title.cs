using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void PlayBtn()
    {
        // �Ѿ ���� �̸��� ��ȣ �ȿ� �ִ´�
        SceneManager.LoadScene("Garage");
    }
}