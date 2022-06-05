using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    
    private float countTime = 0.000f;//�����l0.000
    public bool StopFlag = false;
    
    void Update()
    {
        countTime += Time.deltaTime;//�{�J�E���g�^�C��
        GetComponent<Text>().text = countTime.ToString("F2");//Text�ɕ\��

        if (StopFlag==true)
        {
            GetComponent<Text>().text = countTime.ToString("F2");//Text�ɕ\��
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            StopFlag = true;
            Debug.Log("StopFlag=true");
        }

    }


    
}
