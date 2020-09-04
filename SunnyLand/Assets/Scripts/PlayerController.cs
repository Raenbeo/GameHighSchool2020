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

    public bool isTouchLadder = false;
    public bool isClimbing = false;

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

        if(!isClimbing)
        {
            if (xAxis > 0)
            {
                sprite.localScale = new Vector3(1, 1, 1);
            }
            else if (xAxis < 0)
            {
                sprite.localScale = new Vector3(-1, 1, 1);
            }

            if (Input.GetKeyDown(KeyCode.Space) && m_jumpCount == 0)
            {
                m_Rigidbody2D.AddForce(Vector3.up * JumpPower);
                m_jumpCount++;
            }
        }

        if (isTouchLadder && Mathf.Abs(yAxis) > 0.5f)
        {
            isClimbing = true;
            m_Rigidbody2D.constraints = m_Rigidbody2D.constraints | RigidbodyConstraints2D.FreezePosition;
            Vector3 move = Vector3.zero;
            move.x = xAxis * Time.deltaTime * 2.2f;
            move.y = yAxis * Time.deltaTime * 2.2f;

            transform.position += move;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                climbingExit();
            }

        }
        else
        {
            //climbingExit();
        }

        if(yAxis > 0 && isClimbing)
        {
            // m_Rigidbody2D.AddForce(Vector3.up * 0.2f);
            velocity.y = yAxis * YaxisSpeed;
            m_Rigidbody2D.velocity = velocity;
        }

        //var animator = GetComponent<Animator>();
        animator.SetFloat("velocityY", velocity.y);

    }

    public void climbingExit()
    {
        m_Rigidbody2D.constraints = m_Rigidbody2D.constraints & ~RigidbodyConstraints2D.FreezePosition;
        isClimbing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D contact in collision.contacts)
        {
            if(contact.normal.y > 0.4f)
            {
                m_jumpCount = 0;


                if(contact.rigidbody)
                {
                    var hp = contact.rigidbody.GetComponent<HPComponent>();
                    if(hp)
                    {
                        Destroy(hp.gameObject);
                    }
                }
                     
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "ladder")
        {
            isTouchLadder = true;
            animator.SetBool("isLadder", isTouchLadder);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        {
            climbingExit();
            isTouchLadder = false;
            animator.SetBool("isLadder", isTouchLadder);
        }
        else if(collision.tag == "Item")
        {
           var item =  collision.GetComponent<ItemComponet>();
            if(item != null)
            {
                item.getItem();
            }

        }
    }

}
