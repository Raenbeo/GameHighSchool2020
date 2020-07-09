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

    public void GameStart()
    {
        m_Player.gameObject.SetActive(true);
        m_Player.transform.position = m_StartPoint.transform.position;
        m_Player.transform.rotation = m_StartPoint.transform.rotation;

        m_ClearUi.gameObject.SetActive(true);
        m_ScoreUi.gameObject.SetActive(true);
    }

    public void GameClear()
    {

    }

    public void ReturnToStartPoint()
    {
        m_Player.transform.position = m_StartPoint.transform.position;
        m_Player.transform.rotation = m_StartPoint.transform.rotation;
    }


}
