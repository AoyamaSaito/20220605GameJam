using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] RiverManager _fallRiver;
    [SerializeField] GameObject _damageParticle;
    [SerializeField] GameObject _oishiiParticle;
    [SerializeField] GameObject _gameClearPanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] float m_speed = 10f;
    [SerializeField] float _SpeedChange = 0.2f;
    [Header("HP")]
    [SerializeField] int hp = 5;
    [SerializeField] Text _hpText = null;
    [SerializeField] string _speedUpTag = "SpeedUp";
    [SerializeField] string _speedDownTag = "SpeedDown";
    [SerializeField] string _clearTag = "GameClear";


    float _gameSpeed = 1;
    Rigidbody2D _rb2D;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _hpText.text = hp.ToString();
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
            StartCoroutine(HitEffectCor(_oishiiParticle));
            _gameSpeed += _SpeedChange;
            if (_fallRiver)
            {
                _fallRiver.UpdateSpeed(_gameSpeed);
            }
        }
        else if (hitTag == _speedDownTag)
        {
            Destroy(col.gameObject);
            StartCoroutine(HitEffectCor(_damageParticle));
            _gameSpeed -= _SpeedChange;
            _gameSpeed = Mathf.Max(0.6f, _gameSpeed);
            if (_fallRiver)
            {
                _fallRiver.UpdateSpeed(_gameSpeed);
            }

            hp--;
            if(_hpText)
            {
                _hpText.text = hp.ToString();
            }
            if(hp <= 0)
            {
                Destroy(gameObject); 
                _fallRiver?.StopRiver();
                timer?.TimerStop();
                _gameOverPanel?.SetActive(true);
            }
        }
        else if (hitTag == _clearTag)
        {
            _fallRiver?.StopRiver();
            timer?.TimerStop();
            _gameClearPanel?.SetActive(true);
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