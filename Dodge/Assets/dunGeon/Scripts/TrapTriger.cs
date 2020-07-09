using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapTriger : MonoBehaviour
{

    public string TrapKinds = "";
    
    public GameObject m_Enemy = null;
    GameObject enemy;

    public UnityEvent m_OnEnter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.GetComponent<PlayerControllerDunGeon>())
        {
            var player = other.attachedRigidbody.GetComponent<PlayerControllerDunGeon>();
            if(player != null)
            {
                  m_OnEnter.Invoke();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
