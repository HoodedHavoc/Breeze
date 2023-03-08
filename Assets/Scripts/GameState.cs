using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        Time.timeScale = 0f;

    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
