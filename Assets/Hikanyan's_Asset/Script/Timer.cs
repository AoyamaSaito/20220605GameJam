using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    
    private float countTime = 0.000f;//�����l0.000
    private bool StopFlag = false;

    Text _test = null;
    private void Start()
    {
        _test = GetComponent<Text>();
        StopFlag = false;
}

    void Update()
    {
        if (StopFlag == true) this.enabled = false;
        countTime += Time.deltaTime;//�{�J�E���g�^�C��
        _test.text = countTime.ToString("F2");//Text�ɕ\��
       
        if (Input.GetKey(KeyCode.Space))
        {
            TimerStop();
            Debug.Log("StopFlag=true");
        }
    }

    public void TimerStop()
    {
        StopFlag = false;
        _test.text = countTime.ToString("F2");//Text�ɕ\��
        Debug.Log("Nyan");
    }

    
}
