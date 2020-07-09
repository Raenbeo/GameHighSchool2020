using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControllerDunGeon : MonoBehaviour
{
    

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(xAxis,0,zAxis) * speed;
        Rigidbody m_arigidbody = GetComponent<Rigidbody>();
        velocity.y = m_arigidbody.velocity.y;
        m_arigidbody.velocity = velocity;

        //Vector3 movement = velocity * Time.deltaTime;
        //transform.position = transform.position + movement;

    }
    public void Die()
    {
       GameManagerDunGeon gamemanager = FindObjectOfType<GameManagerDunGeon>();
        gamemanager.ReturnToStartPoint();
    }
}
