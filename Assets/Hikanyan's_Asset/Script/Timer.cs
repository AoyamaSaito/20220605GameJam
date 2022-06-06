using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    [SerializeField] Text _timer1;
    [SerializeField] Text _timer2;
    private float countTime = 0.000f;//初期値0.000
    private bool StopFlag = false;

    private void Start()
    {
        StopFlag = false;
}

    void Update()
    {
        if (StopFlag == true) this.enabled = false;
        countTime += Time.deltaTime;//＋カウントタイム
        _timer1.text = countTime.ToString("F2");//Textに表示
       
        if (Input.GetKey(KeyCode.Space))
        {
            TimerStop();
            Debug.Log("StopFlag=true");
        }
    }

    public void TimerStop()
    {
        StopFlag = false;
        _timer2.text = countTime.ToString("F2");//Textに表示
        Debug.Log("Nyan");
    }

    
}
