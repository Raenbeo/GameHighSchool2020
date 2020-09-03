using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemComponet : MonoBehaviour
{
    public UnityEvent getItemEvent;

    public virtual void getItem()
    {
        getItemEvent.Invoke();
    }
    public void DestorySelf()
    {
        Destroy(gameObject);
    }
    public void playAni()
    {
        var ain = GetComponent<Animator>();
        ain.Play("Item_PickupEffect");
    }
}

