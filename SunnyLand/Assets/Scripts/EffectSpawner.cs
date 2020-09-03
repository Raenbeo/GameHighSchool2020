using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public GameObject EffectPrefab;

    public void SpawnEffect()
    {
        GameObject.Instantiate(EffectPrefab,transform.position,transform.rotation);
    }
}
