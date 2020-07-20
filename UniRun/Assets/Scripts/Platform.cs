using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] m_obstacles;
    public bool m_isTouch = false;

    private void OnEnable()
    {
        m_isTouch = false;
        foreach (var ain in m_obstacles)
        {
            ain.SetActive(false);
            if(Random.Range(0,3) == 0)
                ain.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(m_isTouch == false)
        {
            GameManager.Instance.OnAddScore();
            m_isTouch = true;
        }
    }

}
