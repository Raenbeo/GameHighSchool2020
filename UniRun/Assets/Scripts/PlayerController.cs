using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator m_Animator;
    public Rigidbody2D m_rigidbody2d;

    public AudioSource m_AudioSource;

    public AudioClip m_jump;
    public AudioClip m_Death;

    public bool m_IsGround = false;
    public bool m_IsDead = false;

    public float m_IsJump = 0;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2d = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsDead) return;

       m_Animator.SetBool("IsGround", m_IsGround);

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    public void Jump()
    {
         if (m_IsJump < 2)
         {
             m_rigidbody2d.velocity = m_rigidbody2d.velocity * 0.2f;
             m_rigidbody2d.AddForce(Vector2.up * speed);
             m_IsJump++;
             m_AudioSource.clip = m_jump;
             m_AudioSource.Play();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            m_AudioSource.clip = m_Death;
            m_AudioSource.Play();
            m_IsDead = true;
            m_Animator.SetBool("IsDead",m_IsDead);
            GameManager.Instance.OnPlayerDead();
        }
    }


}
