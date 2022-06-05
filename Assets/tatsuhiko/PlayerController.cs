using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] RiverManager _fallRiver;
    [SerializeField] float m_speed = 10f;
    [SerializeField] string _speedUpTag = "SpeedUp";
    [SerializeField] string _speedDownTag = "SpeedDown";
    [SerializeField] string _clearTag = "GameClear";

    float _gameSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CorutineTest());
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(h * m_speed ,0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _speedUpTag)
        {
            _gameSpeed += 0.1f;
            _fallRiver.UpdateSpeed(_gameSpeed);
        }
        else if(collision.gameObject.tag == _speedDownTag)
        {
            _gameSpeed -= 0.1f;
            _fallRiver.UpdateSpeed(_gameSpeed);
        }
        else if (collision.gameObject.tag == _clearTag)
        {
            _fallRiver.StopRiver();
            timer.TimerStop();
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
}