using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_rigidbody2d;

    public bool m_IsGround = false;
    public bool m_IsDead = false;

    public float m_IsJump = 0;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       m_Animator.SetBool("IsGround", m_IsGround);
       
        if (Input.GetKeyDown(KeyCode.Space) && m_IsJump < 2)
        {
            m_rigidbody2d.velocity = m_rigidbody2d.velocity * 0.2f;
            m_rigidbody2d.AddForce(Vector2.up * speed);
            m_IsJump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_IsGround = true;
            m_IsJump = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_IsGround = false;
        }
    }

}
