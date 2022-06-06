using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestoy : MonoBehaviour
{
    [SerializeField] GameObject _destroyPrefab;

    // Start is called before the first frame update
    private void OnDestroy()
    {
        Destroy(Instantiate(_destroyPrefab, transform.position, Quaternion.identity), 2f);
    }
}
