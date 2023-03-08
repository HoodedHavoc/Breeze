using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject player;


    
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame


    public void Avtivate()
    {
        gameObject.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }


}
