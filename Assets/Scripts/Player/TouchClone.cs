using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchClone : MonoBehaviour
{
    public GameObject cube;
    public GameObject clone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("toucning");
                clone = Instantiate(cube, transform.position, transform.rotation) as GameObject;
            }
        }

        
    }
}
