using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        var collider = GetComponent<BoxCollider2D>();
        width = collider.size.x-1;
    }

    void Update()
    {
        if(transform.position.x < -width)
        {
            transform.position += Vector3.right * 2f * width;
        }
    }
}
