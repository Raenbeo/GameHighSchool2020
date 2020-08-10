using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject asd;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray();
        ray.origin = Vector3.zero;
        ray.direction = Vector3.forward;

        //LayerMask.GetMask("1", "2")
        if (Physics.Raycast(ray,out hit, 3f,LayerMask.GetMask("1","2"), QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.collider.name);
           GameObject ain =  GameObject.Instantiate(asd,hit.point,Quaternion.identity);
           ain.transform.localScale = 0.05f * Vector3.one;
        }
        Debug.DrawLine(Vector3.zero, Vector3.zero + Vector3.forward * 100f, Color.red); ;

    }
}
