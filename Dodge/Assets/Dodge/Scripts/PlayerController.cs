using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public GameManager  m_GameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMove(speed);
    }

    public void playerMove(float speed)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        //float xAxis = Input.GetAxis("Horizontal");
        //float yAxis = Input.GetAxis("Vertical");
        //float fire1Axis = Input.GetAxis("Fire1");

        //if(fire1Axis >= 0.5)
        //{
        //    Debug.Log("파이어엑시스");
        //    Die();
        //}

        //rigidbody.AddForce(new Vector3(xAxis,0,yAxis) * speed);

        if (Input.GetKey(KeyCode.DownArrow))
            rigidbody.AddForce(Vector3.back * speed);
        else if (Input.GetKey(KeyCode.UpArrow))
            rigidbody.AddForce(Vector3.forward * speed);
        else if (Input.GetKey(KeyCode.LeftArrow))
            rigidbody.AddForce(Vector3.left * speed);
        else if (Input.GetKey(KeyCode.RightArrow))
            rigidbody.AddForce(Vector3.right * speed);
        else if (Input.GetKeyDown(KeyCode.Space))
            Die();
    }

    public void Die()
    {
        Debug.Log("뒈쥠");
        m_GameManager.GameOver();
    }
}
