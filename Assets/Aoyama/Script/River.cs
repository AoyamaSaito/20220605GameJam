using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public event Action OutAria;
    [HideInInspector] 
    public float _speedMagnification = 1;

    [SerializeField]
    private float _destroyY = -15f;

    private float _speed = 0.1f;
    public FallRiver _fallRiver;

    private void FixedUpdate()
    {
        Down();
    }

    private void Down()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - _speed * _speedMagnification, transform.position.z);

        if (transform.position.y <= _destroyY)
        {
            Destroy(gameObject);
            _fallRiver.RiverRemove(this);
            OutAria();
        }
    }
}
