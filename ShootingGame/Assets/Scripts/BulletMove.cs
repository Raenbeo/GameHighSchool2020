using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject m_Bullet;

    public float speed = 30;

    public float destoryTime = 5;

    float InGameTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InGameTime += Time.deltaTime;

        if(destoryTime <= InGameTime)
        {
            GameObject.Destroy(m_Bullet);
        }

        Vector3 move = transform.up * speed * Time.deltaTime;
        transform.position += move;
    }
}
