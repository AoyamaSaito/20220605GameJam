using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    [SerializeField] Text _timer1;
    [SerializeField] Text _timer2;
    private float countTime = 0.000f;//�����l0.000
    private bool StopFlag = false;

    private void Start()
    {
        StopFlag = false;
}

    void Update()
    {
        if (StopFlag == true) this.enabled = false;
        countTime += Time.deltaTime;//�{�J�E���g�^�C��
        _timer1.text = countTime.ToString("F2");//Text�ɕ\��
       
        if (Input.GetKey(KeyCode.Space))
        {
            TimerStop();
            Debug.Log("StopFlag=true");
        }
    }

    public void TimerStop()
    {
        StopFlag = false;
        _timer2.text = countTime.ToString("F2");//Text�ɕ\��
        Debug.Log("Nyan");
    }

    
}
