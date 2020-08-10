using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlueCube : MonoBehaviour
{
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        GameManager.instance.MinusLife();
        Destroy(gameObject);
        Debug.Log("파란 큐브를 눌럿습니다 생명을 깍습니다..");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Speed *Time.deltaTime;
        if (transform.position.y < -10)
        {
            GameManager.instance.AddScore();
            Destroy(gameObject);
        }
    }
}
