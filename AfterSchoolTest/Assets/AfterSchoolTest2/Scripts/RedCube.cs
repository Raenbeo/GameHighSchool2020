using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedCube : MonoBehaviour
{
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        GameManager.instance.AddScore();
        Destroy(gameObject);
        Debug.Log("빨간 큐브를 눌렀습니다. 점수를 추가합니다.");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
        if(transform.position.y < -10)
        {
            GameManager.instance.MinusLife();
            Destroy(gameObject);
        }
    }
}
