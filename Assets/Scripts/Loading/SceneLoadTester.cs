using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTester : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Garage");
    }

    public void SceneChangePark()
    {
        SceneManager.LoadScene("Park");
    }

    public void SceneChangeStart()
    {
        SceneManager.LoadScene("Start");
    }
}
