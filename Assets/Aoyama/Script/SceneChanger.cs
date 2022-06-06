using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChenge(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void ShatDown()
    {
        Application.Quit();
    }
}
