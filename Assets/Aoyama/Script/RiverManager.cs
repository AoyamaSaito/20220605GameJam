using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RiverManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _firstRiver;
    [SerializeField]
    private GameObject _secondRiver;
    [SerializeField]
    private GameObject _thirdRiver;
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

        go = Instantiate(_secondRiver, new Vector3(0, _downInterval, 0), Quaternion.identity);
        river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river._fallRiver = this;
        river.OutAria += InstantiateRiver;

        go = Instantiate(_thirdRiver, new Vector3(0, _downInterval * 2, 0), Quaternion.identity);
        river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river._fallRiver = this;
        river.OutAria += InstantiateRiver;
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
        Debug.Log("Instantiate");
        if(_index == _rivers.Length || _rivers == null)
        {
            var go1 = Instantiate(_goalRiver, transform.position, Quaternion.identity);
            var river1 = go1.GetComponent<River>();
            _onStageRiver.Add(river1);
            river1._fallRiver = this;
            river1.OutAria += InstantiateRiver;
        }

        var go = Instantiate(_rivers[_index], transform.position, Quaternion.identity);
        var river = go.GetComponent<River>();
        _onStageRiver.Add(river);
        river._fallRiver = this;
        river.OutAria += InstantiateRiver;
        _index++;
    }

    public void RiverRemove(River r)
    {
        _onStageRiver.Remove(r);
    }
}
