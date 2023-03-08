using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlowerControl : MonoBehaviour
{
    Vector3 flowerStartPos;
    Vector3 currentFlowerPos;

    public int pointCounter;

    public Menu death;

    public bool dead;

    //public GameObject body;
    
    
    Rigidbody rigidBody;
    Collider flowerCollider;

    public float smoothSpeed = 1f;
    bool flowerMovingBack = false;
    bool flowerIsMoving = false;

    Quaternion rotation;

    private void Awake()
    {

        rigidBody = gameObject.GetComponent<Rigidbody>();
        flowerCollider = gameObject.GetComponent<Collider>();

        flowerStartPos = new Vector3(0, 3.5f, 0);
    }


    void Update()
    {
        currentFlowerPos = transform.position;

        if (flowerMovingBack) transform.position = Vector3.Lerp(currentFlowerPos, flowerStartPos, smoothSpeed * Time.deltaTime);

        if (gameObject.transform.position != flowerStartPos) flowerIsMoving = true;

        if (flowerIsMoving)
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BreezeCollider")
        {

            //Debug.Log("collision with cube");
            rigidBody.useGravity = true;
            StartCoroutine(FlowerMoving());
        }
    }

    IEnumerator FlowerMoving()
    {

        yield return new WaitForSeconds(1.5f);

        flowerMovingBack = true;

        if (gameObject.transform.position == flowerStartPos)
        {
            flowerMovingBack = false;
            rigidBody.useGravity = false;
        }

        
    }
}
