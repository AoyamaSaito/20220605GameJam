using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public event Action OutAria;

    [SerializeField]
    private float _destroyY = -40;

    float _timer = 0;

    private void Update()
    {
        Down();
    }

    private void Down()
    {
        _timer += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y - _timer, transform.position.y);

        if (transform.position.y <= _destroyY)
        {
            Destroy(gameObject);
            OutAria();
        }
    }
}
