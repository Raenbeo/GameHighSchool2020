using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ItemComponet> items = new List<ItemComponet>();
    public bool isPlaying = false;
    public GameObject GameClearTxt;
    // Start is called before the first frame update
    void Start()
    {
        items.AddRange(FindObjectsOfType<ItemComponet>());
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) return;
        bool result = true;
        foreach(var item in items)
        {
            if (item != null)
                result = false;
        }
        if(result)
        {
            isPlaying = false;
            GameClear();
        }
    }
    public void GameOver()
    {

    }
    public void GameClear()
    {
        GameClearTxt.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameStart()
    {

    }
}
