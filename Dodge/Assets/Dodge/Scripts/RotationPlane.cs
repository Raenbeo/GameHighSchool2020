using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlane : MonoBehaviour
{
    public float m_rotationSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, m_rotationSpeed * Time.deltaTime, 0));
    }
}
