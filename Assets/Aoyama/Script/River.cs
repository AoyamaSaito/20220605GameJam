using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public event Action OutAria;

    [HideInInspector]
    public float _speed = 0.000001f;

    [SerializeField]
    private float _destroyY = -15f;

    float _timer = 0f;
    Transform tr;

    private void Start()
    {
        tr = transform;
    }

    private void FixedUpdate()
    {
        Down();
    }

    private void Down()
    {
        float _i = 0.1f;
        transform.position = new Vector3(tr.position.x, transform.position.y - _i, tr.position.z);

        if (transform.position.y <= _destroyY)
        {
            Destroy(gameObject);
            FallRiver.Instance.RiverRemove(this);
            OutAria();
        }
    }
}
