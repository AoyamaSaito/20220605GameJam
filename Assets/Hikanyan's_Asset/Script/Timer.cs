using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;
    private float countTime = 0.000f;

    private void Start()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0.500f;
    }
    void Update()
    {
        countTime += Time.deltaTime;
        fadeTime -= fadeTime * Time.deltaTime;
        GetComponent<Text>().text = countTime.ToString("F2");
        
        colorChange();
        
    }
    void colorChange()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = countTime / fadeTime;
        Debug.Log("colorChange");
    }
}
