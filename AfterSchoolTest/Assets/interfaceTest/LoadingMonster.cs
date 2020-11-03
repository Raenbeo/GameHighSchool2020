using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMonster : MonoBehaviour
{
    public int m_cham = 1;
    public int m_minion = 1;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            var cham = Resources.Load(string.Format("챔피언{0}",m_cham));
            if (cham == null) return;
            var chamobj = GameObject.Instantiate(cham) as GameObject;
            m_cham++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var minion = Resources.Load(string.Format("미니언{0}", m_cham));
            if (cham == null) return;
            var minionobj = GameObject.Instantiate(minion) as GameObject;
            m_minion++;
        }
    }
}
