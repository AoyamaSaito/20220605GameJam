using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    
    private float countTime = 0.000f;//初期値0.000
    public bool StopFlag = false;

    Text _test = null;
    private void Start()
    {
        _test = GetComponent<Text>();
    }

    void Update()
    {
        countTime += Time.deltaTime;//＋カウントタイム
        _test.text = countTime.ToString("F2");//Textに表示
       
        if (Input.GetKey(KeyCode.Space))
        {
            TimerStop();
            Debug.Log("StopFlag=true");
        }
    }

    public void TimerStop()
    {
        _test.text = countTime.ToString("F2");//Textに表示
        Debug.Log("Nyan");
    }

    
}
