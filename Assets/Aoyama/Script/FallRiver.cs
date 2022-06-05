using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FallRiver : SingletonMonoBehaviour<FallRiver>
{
    [SerializeField]
    private GameObject _firstRiver;
    [SerializeField]
    private GameObject[] _rivers;
    [SerializeField]
    private GameObject _goalRiver;
    [SerializeField] 
    private float _downInterval = 30;

    List<River> _onStageRiver = new ();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _onStageRiver = new List<River>(0);
        _rivers.OrderBy(go => Guid.NewGuid());

        var go = Instantiate(_firstRiver, Vector3.zero, Quaternion.identity);
        var river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river._fallRiver = this;
        river.OutAria += InstantiateRiver;

        var go1 = Instantiate(_firstRiver, new Vector3(0, _downInterval, 0), Quaternion.identity);
        var river1 = go1.GetComponent<River>();
        _onStageRiver.Add(river1);
        river1._fallRiver = this;
        river1.OutAria += InstantiateRiver;

        var go2 = Instantiate(_firstRiver, new Vector3(0, _downInterval * 2, 0), Quaternion.identity);
        var river2 = go2.GetComponent<River>();
        _onStageRiver.Add(river2);
        river2._fallRiver = this;
        river2.OutAria += InstantiateRiver;
    }

    public void StopRiver()
    {
        _onStageRiver.ForEach(go => go._speedMagnification = 0);
    }

    public void UpdateSpeed(float _speedChange)
    {
        _onStageRiver.ForEach(go => go._speedMagnification = _speedChange);
    }

    int _index = 0;
    private void InstantiateRiver()
    {
        if(_index == _rivers.Length)
        {
            var go1 = Instantiate(_goalRiver, transform.position, Quaternion.identity);
            var river1 = go1.GetComponent<River>();
            _onStageRiver.Add(river1);
            river1._fallRiver = this;
            river1.OutAria += InstantiateRiver;
        }

        _index++;
        var go = Instantiate(_rivers[_index], transform.position, Quaternion.identity);
        var river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river._fallRiver = this;
        river.OutAria += InstantiateRiver;
    }

    public void RiverRemove(River r)
    {
        _onStageRiver.Remove(r);
    }
}
