using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartEvent : MonoBehaviour
{
 
        public void OnClickStartButton()
        {
            Debug.Log("UI�������ꂽGameScreen1�Ɉڍs");
            SceneManager.LoadScene("GameScreen1");
        }
    
}
