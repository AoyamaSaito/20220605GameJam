using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] RiverManager _fallRiver;
    [SerializeField] GameObject _damageParticle;
    [SerializeField] GameObject _oishiiParticle;
    [SerializeField] float m_speed = 10f;
    [SerializeField] float _SpeedChange;
    [SerializeField] string _speedUpTag = "SpeedUp";
    [SerializeField] string _speedDownTag = "SpeedDown";
    [SerializeField] string _clearTag = "GameClear";

    float _gameSpeed = 1;
    Rigidbody2D _rb2D;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _rb2D.velocity = new Vector2(h * m_speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitObject(collision, collision.gameObject.tag); 
    }

    void HitObject(Collider2D col, string hitTag)
    {
        if (hitTag == _speedUpTag)
        {
            Destroy(col.gameObject);
            HitEffectCor(_oishiiParticle);
            _gameSpeed += _SpeedChange;
            if (_fallRiver)
            {
                _fallRiver.UpdateSpeed(_gameSpeed);
            }
        }
        else if (hitTag == _speedDownTag)
        {
            StartCoroutine(HitEffectCor(_damageParticle));
            _gameSpeed -= _SpeedChange;
            if (_fallRiver)
            {
                _fallRiver.UpdateSpeed(_gameSpeed);
            }
        }
        else if (hitTag == _clearTag)
        {
            if (_fallRiver)
            {
                _fallRiver.StopRiver();
            }
            if (timer)
            {
                timer.TimerStop();
            }
        }
    }

    //float _testSpeed = 0;
    //IEnumerator CorutineTest() //IEmurator
    //{
    //  _testSpeed = 1;
    //  yield return new WaitForSeconds(1f); //yield return new
    //  _testSpeed = 0;

    //  bool i = false;
    //  while(i!)
    //  {
    //      break;
    //  }
    //}

    IEnumerator HitEffectCor(GameObject go)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
    }
}