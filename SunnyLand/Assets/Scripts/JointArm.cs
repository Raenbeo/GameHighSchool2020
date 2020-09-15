using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointArm : MonoBehaviour
{
    public Transform Target;

    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        if(!Target)
        transform.position = Target.position + Offset;
    }
}
