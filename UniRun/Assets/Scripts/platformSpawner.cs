using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{

    public GameObject m_PlatformPrefabs;
    public GameObject[] m_Platforms;

    public float m_MinY = -2f;
    public float m_MaxY = 2f;

    public float m_MinDelay = 3f;
    public float m_MaxDelay = 5f;

    public float m_SpawnDelay = 0;
    public int m_PlatformCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Platforms = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            m_Platforms[i] = GameObject.Instantiate(m_PlatformPrefabs);
            m_Platforms[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_SpawnDelay <= 0)
        {
            m_Platforms[m_PlatformCount].SetActive(false);
            m_Platforms[m_PlatformCount].SetActive(true);

            Vector2 spawnPosition = new Vector2(12f, Random.Range(m_MinY, m_MaxY));
            m_Platforms[m_PlatformCount].transform.position = spawnPosition;
            
            m_PlatformCount = (m_PlatformCount + 1) % 3;

            m_SpawnDelay = Random.Range(m_MinDelay,m_MaxDelay);
        }
        m_SpawnDelay -= Time.deltaTime;
    }
}
