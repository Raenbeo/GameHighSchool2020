using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public float CoolDown = 0;

    public float InGameTime =0;

    public GameObject Red;
    public GameObject Blue;

    public Transform[] SpawnPoint;

    public void SpawnStart()
    {
        StartCoroutine(SpawnProcess());
    }

    public IEnumerator SpawnProcess()
    {
        //cube spawn
        for(int i =0;i< SpawnPoint.Length;i++)
        {
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                int random2 = Random.Range(0, 2);
                if(random2 == 0)
                {
                    var ain = GameObject.Instantiate(Red);
                    ain.transform.position = SpawnPoint[i].position;
                    ain.transform.rotation = SpawnPoint[i].rotation;
                    ain.transform.eulerAngles = new Vector3(Random.Range(0,360f), Random.Range(0, 360f), Random.Range(0, 360f));
                }
                else
                {
                    var ain = GameObject.Instantiate(Blue);
                    ain.transform.position = SpawnPoint[i].position;
                    ain.transform.rotation = SpawnPoint[i].rotation;
                    ain.transform.eulerAngles = new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
                }
            }
        }

        float SpawnDelay = Random.Range(3,5);
        yield return new WaitForSeconds(SpawnDelay);

        //cube respawn
        StartCoroutine(SpawnProcess());

    }

    void Start()
    {
        SpawnStart();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
