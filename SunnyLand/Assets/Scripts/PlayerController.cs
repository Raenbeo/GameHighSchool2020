using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    public Animator animator;

    public float XaxisSpeed = 3f;
    public float YaxisSpeed = 3f;
    public float JumpPower = 3f;

    public Transform sprite;

    public int m_jumpCount = 0;

    public bool isLadder = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * XaxisSpeed;
        m_Rigidbody2D.velocity = velocity;

        if(xAxis > 0)
        {
            sprite.localScale = new Vector3(1,1,1);
        }
        else if (xAxis < 0)
        {
            sprite.localScale = new Vector3(-1,1,1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && m_jumpCount == 0)
        {
            m_Rigidbody2D.AddForce(Vector3.up * JumpPower);
            m_jumpCount++;
        }

        if(yAxis > 0 && isLadder)
        {
            // m_Rigidbody2D.AddForce(Vector3.up * 0.2f);
            velocity.y = yAxis * YaxisSpeed;
            m_Rigidbody2D.velocity = velocity;
        }

        //var animator = GetComponent<Animator>();
        animator.SetFloat("velocityY", velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D contact in collision.contacts)
        {
            if(contact.normal.y > 0.5f)
            {
                m_jumpCount = 0;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "ladder")
        {
            isLadder = true;
            animator.SetBool("isLadder", isLadder);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        {
            isLadder = false;
            animator.SetBool("isLadder", isLadder);
        }
    }

}
