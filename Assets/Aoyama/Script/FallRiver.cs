using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRiver : SingletonMonoBehaviour<FallRiver>
{
    [SerializeField]
    private GameObject _firstRiver;
    [SerializeField]
    private GameObject[] _rivers;
    [SerializeField]
    private GameObject[] _goalRiver;
    [SerializeField] 
    private float _downInterval = 30;
    [SerializeField] 
    private float _speedUpDown = 1f;

    List<River> _onStageRiver = new ();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _onStageRiver = new List<River>(0);

        var go = Instantiate(_firstRiver, Vector3.zero, Quaternion.identity);
        var river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river.OutAria += InstantiateRiver;

        var go1 = Instantiate(_firstRiver, new Vector3(0, _downInterval, 0), Quaternion.identity);
        var river1 = go1.GetComponent<River>();
        _onStageRiver.Add(river1);
        river1.OutAria += InstantiateRiver;

        var go2 = Instantiate(_firstRiver, new Vector3(0, _downInterval * 2, 0), Quaternion.identity);
        var river2 = go2.GetComponent<River>();
        _onStageRiver.Add(river2);
        river2.OutAria += InstantiateRiver;
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        //_onStageRiver.ForEach(go => go._speed = _speedUpDown);
    }

    private void InstantiateRiver()
    {
        var go = Instantiate(_firstRiver, transform.position, Quaternion.identity);
        var river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river.OutAria += InstantiateRiver;
    }

    public void RiverRemove(River r)
    {
        _onStageRiver.Remove(r);
    }
}
