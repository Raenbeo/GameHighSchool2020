using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public float speed = 30;
    float inGameTime22 = 0;
    public float setDeathTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.up * speed * Time.deltaTime;
        transform.position += move;

        inGameTime22 += Time.deltaTime;
        if (setDeathTime <= inGameTime22)
        {
            Die();
            inGameTime22 = 0;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
