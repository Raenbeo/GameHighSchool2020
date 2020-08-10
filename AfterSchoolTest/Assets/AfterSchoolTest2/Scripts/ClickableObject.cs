using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour /*,IPointerDownHandler*/
{
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("오브젝트를 눌럿습니다.");

    //    //throw new System.NotImplementedException();
    //}

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        Debug.Log("오브젝트를 눌럿습니다.");  
    }

    //private void OnMouseDown()
    //{
    //}

}
