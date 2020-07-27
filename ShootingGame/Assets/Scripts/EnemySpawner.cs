using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] Pos;

    public float SpawnIntervalMin = 2f;
    public float SpawnIntervalMax = 6f;
    public float SpawnCooldown = 0f;

    public int MinSpawnCount = 1;
    public int MaxSpawnCount = 4;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCooldown = Random.Range(SpawnIntervalMin,SpawnIntervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnCooldown <= 0)
        {
            int SpawnCount = Random.Range(MinSpawnCount,MaxSpawnCount);

            List<int> spawnNums = new List<int>();
            for(int i =0;i<SpawnCount;i++)
            {
                int SpawnNum;
                do
                {
                    SpawnNum = Random.Range(0, Pos.Length);
                }
                while (spawnNums.Contains(SpawnNum));
                spawnNums.Add(SpawnNum);
            }

            foreach (var ain in spawnNums)
            {
                GameObject enemy = GameObject.Instantiate(Enemy,Pos[ain].position,Pos[ain].rotation);
            }
            SpawnCooldown = Random.Range(SpawnIntervalMin,SpawnIntervalMax);
        }
        SpawnCooldown -= Time.deltaTime;
    }
}
