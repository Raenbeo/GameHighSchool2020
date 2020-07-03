using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    float inGameTime = 0;
    public float setDeathTime = 0;
    public Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Velocity * speed;

        inGameTime += Time.deltaTime;

        if (setDeathTime <= inGameTime)
        {
            Destroy(gameObject);    
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player")
        {
            var player = other.attachedRigidbody.GetComponent<PlayerController>();
            
            player.Die();
        }
     
    }

}
