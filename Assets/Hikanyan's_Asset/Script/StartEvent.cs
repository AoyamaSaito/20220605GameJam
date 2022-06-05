using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartEvent : MonoBehaviour
{
 
        public void OnClickStartButton()
        {
            Debug.Log("UI‚ª‰Ÿ‚³‚ê‚½GameScreen1‚ÉˆÚs");
            SceneManager.LoadScene("GameScreen1");
        }
    
}
