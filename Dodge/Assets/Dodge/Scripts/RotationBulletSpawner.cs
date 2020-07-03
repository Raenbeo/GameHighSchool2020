using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RotationBulletSpawner : MonoBehaviour
{
    public GameObject m_Bullet;
    public float m_rotationSpeed = 60f;

    float inGameTime = 0;
    public float setAttackTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0,Random.Range(0,360),0);
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
    }
}
