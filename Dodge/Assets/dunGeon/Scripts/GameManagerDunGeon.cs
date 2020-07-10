using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerDunGeon : MonoBehaviour
{
    public Transform m_StartPoint;
    public PlayerControllerDunGeon m_Player;

    public Text m_ClearUi;
    public Text m_ScoreUi;

    public bool m_IsPlaying;
    public float m_Score;

    void Start()
    {
        m_IsPlaying = true;
    }
    void Update()
    {
        if (m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScoreUi.text = string.Format("Score : {0}", m_Score);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        m_Score = 0;
        m_IsPlaying = true;
       
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.transform.position;
        m_Player.transform.rotation = m_StartPoint.transform.rotation;

        m_ClearUi.gameObject.SetActive(true);
        m_ScoreUi.gameObject.SetActive(true);
    }

    public void GameClear()
    {
        m_Player.gameObject.SetActive(false);
        m_ClearUi.gameObject.SetActive(true);   
        m_ScoreUi.gameObject.SetActive(true);

        //var enemisType1 = FindObjectsOfType<RotationBulletSpawner>();
        //foreach (var ain in enemisType1)
        //{
        //ain.gameObject.SetActive(false);
        //}

        //var enemisType2 = FindObjectsOfType<BulletSpawner>();
        //foreach (var ain in enemisType2)
        //{
        //ain.gameObject.SetActive(false);
        //}

        SetActivityAllGameObject(typeof(BulletSpawner), false);
        SetActivityAllGameObject(typeof(RotationBulletSpawner), false);


        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }


        m_IsPlaying = false;

        float topScore = PlayerPrefs.GetFloat("TopScore", 999);
        float secondScore = PlayerPrefs.GetFloat("SecondScore", 999);
        float thirdScore = PlayerPrefs.GetFloat("ThirdScore", 999);
    
        if (topScore > m_Score)
        {
            thirdScore =  secondScore;
            secondScore = topScore;
            topScore = m_Score;
        }
        else if (secondScore > m_Score)
        {
            thirdScore = secondScore;
            secondScore = m_Score;
        }
        else if (thirdScore > m_Score)
        {
            thirdScore = m_Score;
        }




        PlayerPrefs.SetFloat("TopScore", topScore);
        PlayerPrefs.SetFloat("SecondScore", secondScore);
        PlayerPrefs.SetFloat("ThirdScore", thirdScore);
        PlayerPrefs.Save();

        m_ClearUi.text = string.Format("GameClear \n 1위:{0} 2위:{1} 3위:{2}", topScore, secondScore, thirdScore);

    }

    public void SetActivityAllGameObject(Type type , bool activity)
    {
        var enemisType = FindObjectsOfType(type);
        foreach (var ain in enemisType)
        {   
            var qAin = (MonoBehaviour)ain;
            qAin.gameObject.SetActive(activity);
        }
    }

    public void ReturnToStartPoint()
    {
        m_Player.transform.position = m_StartPoint.transform.position;
        m_Player.transform.rotation = m_StartPoint.transform.rotation;
    }


}
