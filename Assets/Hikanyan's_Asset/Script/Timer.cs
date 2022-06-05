using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    
    private float countTime = 0.000f;//初期値0.000

    
    void Update()
    {
        countTime += Time.deltaTime;//＋カウントタイム
        GetComponent<Text>().text = countTime.ToString("F2");//Textに表示
               
    }
    
}
