using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            var player = collision.rigidbody.GetComponent<PlayerControllerDunGeon>();
            if (player != null)
                player.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
