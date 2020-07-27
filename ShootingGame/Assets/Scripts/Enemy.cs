using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject m_Bullet;

    public Transform m_BulletSpanwPos;

    public Animator m_Animator;


    public bool m_IsDead = false;


    float inGameTime = 0;
  
    public float setAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsDead) return;

        m_Animator.SetBool("IsDead", m_IsDead);

        inGameTime += Time.deltaTime;
       
        if (setAttackTime <= inGameTime)
        {
            Attack();
            inGameTime = 0;
        }
       
    }
   
    public void Attack()
    {
       GameObject bullet = GameObject.Instantiate(m_Bullet);
        bullet.transform.position = m_BulletSpanwPos.transform.position;
        bullet.transform.rotation = m_BulletSpanwPos.transform.rotation;
    }
    public void DestroyObject()
    {
        GameManager.Instance.AddScore();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="PlayerBullet")
        {
            m_IsDead = true;
            m_Animator.SetBool("IsDead", m_IsDead);
            Debug.Log("saddasd");
        }
    }
}
