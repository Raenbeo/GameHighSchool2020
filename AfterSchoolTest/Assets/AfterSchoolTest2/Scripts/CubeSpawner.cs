using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float CoolDown = 0;

    public float InGameTime =0;


    public GameObject Red;
    public GameObject Blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InGameTime += Time.deltaTime;
        if(InGameTime >= CoolDown)
        {

                

            InGameTime = 0;
        }
    }
}
