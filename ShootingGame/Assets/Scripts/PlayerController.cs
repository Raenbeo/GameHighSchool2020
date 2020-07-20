using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject m_Bullet;
    public GameObject m_BulletSpanwPos;


    public float speed = 30;

    float inGameTime = 0;
    public float setAttackTime = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inGameTime += Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow)) transform.position += Vector3.left * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position += Vector3.down * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += Vector3.up * speed * Time.deltaTime;

        if (setAttackTime <= inGameTime)
        {
            Attack();
            inGameTime = 0;
        }
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = m_BulletSpanwPos.transform.position;
        }
    }
}



