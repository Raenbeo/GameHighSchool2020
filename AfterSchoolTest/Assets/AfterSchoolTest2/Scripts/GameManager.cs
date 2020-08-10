using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Life = 0;
    public int Score = 0;

    public bool IsPlaying = false;

    public Text LIFE;
    public Text SCORE;
    public GameObject GameOver;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddScore()
    {
        Score += 1;
    }
    public void MinusScore()
    {
        Score -= 1;
    }
    public void MinusLife()
    {
        Life -= 1;
        if(Life == 0)
        {
            IsPlaying = false;
            GameOver.SetActive(true);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        IsPlaying = true;
        GameOver.SetActive(false);
    }

    private void OnMouseDown()
    {
        //if(IsPlaying == false)
        //{
        //    Life = 3;
        //    Score = 0;
        //    IsPlaying = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPlaying == true)
        {
            SCORE.text = string.Format("Score : {0}",Score);
            LIFE.text = string.Format("Life : {0}",Life);
        }

    }
}
