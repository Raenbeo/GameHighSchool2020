using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform m_playerTransfom;

    public GameObject m_Bullet;

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

        if (setAttackTime <= inGameTime)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            var b = bullet.GetComponent<Bullet>();
            b.Velocity = transform.forward;
            inGameTime = 0;
        }

        //GameObject.Find("이름");
        //GameObject.FindWithTag("태그");
        //GameObject.FindObjectOfType<PlayerController>();
       
        GameObject player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            Vector3 attackerPoint = player.transform.position;
            attackerPoint.y = transform.position.y;
            transform.LookAt(attackerPoint);
        }
    }
}
