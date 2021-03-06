﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KimHungKyu
{
    public class FllowBlackground : MonoBehaviour
    {
        public float m_Grid = 20f;

        public GameObject[] m_Background;
        public Transform m_Target;

        public int m_OldMod = 0;

        public void Update()
        {
            int mod = Mathf.RoundToInt(m_Target.position.x / m_Grid); //버림;
            {
                //Mathf.Floor(); 올림
                //Mathf.Ceil();  내림
                //Mathf.ClosestPowerOfTwo(); 반올림
                // grid를 넘어서는 이동이 발생함. 
            }
            //갱신이 필요.
            if (m_OldMod != mod)
            {
                foreach (var background in m_Background)
                {
                    var pos = background.transform.position;
                    pos.x += m_Grid * (mod - m_OldMod);         //수정
                    background.transform.position = pos;
                }
            }
            //추가
            foreach (var background in m_Background)
            {
                var pos = background.transform.position;
                pos.y = m_Target.position.y;
                background.transform.position = pos;
            }
            m_OldMod = mod;
        }
    }
}