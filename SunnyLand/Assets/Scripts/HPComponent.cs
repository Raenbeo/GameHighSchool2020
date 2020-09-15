using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class HPComponent : MonoBehaviour
{
    public UnityEvent OnTakeDamage;
    // Start is called before the first frame update
  
    public virtual void TakeDamage(int damage)
    {
        OnTakeDamage.Invoke();
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
