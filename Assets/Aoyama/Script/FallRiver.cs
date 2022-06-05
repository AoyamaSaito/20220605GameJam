using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRiver : MonoBehaviour
{
    [SerializeField]
    private GameObject _firstRiver;
    [SerializeField]
    private GameObject[] _rivers;
    [SerializeField]
    private GameObject[] _goalRiver;
    [SerializeField] 
    private float DownInterval = 30;

    private void Start()
    {
        Instantiate(_firstRiver, Vector3.zero, Quaternion.identity)
            .GetComponent<River>().OutAria += InstantiateRiver;
        Instantiate(_firstRiver, new Vector3(0, DownInterval, 0), Quaternion.identity)
            .GetComponent<River>().OutAria += InstantiateRiver;
        Instantiate(_firstRiver, new Vector3(0, DownInterval * 2, 0), Quaternion.identity)
            .GetComponent<River>().OutAria += InstantiateRiver;
    }

    private void FixedUpdate()
    {
        
    }

    

    private void InstantiateRiver()
    {
        Instantiate(_firstRiver, transform.position, Quaternion.identity)
            .GetComponent<River>().OutAria += InstantiateRiver;
    }
}
