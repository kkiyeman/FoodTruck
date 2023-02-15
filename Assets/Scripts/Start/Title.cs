using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void PlayBtn()
    {
        // 넘어갈 씬의 이름을 괄호 안에 넣는다
        SceneManager.LoadScene("Garage");
    }
}