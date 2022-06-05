using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllorer : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
