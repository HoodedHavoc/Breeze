using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class PushColliderTouch : MonoBehaviour
{

    public float pushForce = 30f;

    float distanceFromCamera = 6.0f;

    bool breezeActive = false;
    //bool pushingFlower = false;

    Vector3 initialPos;

    private void Awake()
    {
        initialPos = new Vector3(0, -2f, 0);
        transform.position = initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0) //Activates if more than 0 fingers are touching the screen
        {
            Touch touch = Input.GetTouch(0); //"touch" variable used for when fingers touch the screen


            Vector3 touchPos = Camera.main.ScreenToWorldPoint
                (new Vector3(touch.position.x, touch.position.y, distanceFromCamera)); //Gets position where finger is touching the screen, by using camera

            
            
            if (touch.phase == TouchPhase.Began) //When a finger first touches the screen
            {
                //Debug.Log("Touched the screen at " + touch.position);

                transform.position = touchPos; //Resets collider to where finger first touches the screen

                breezeActive = false;
            }
            
            
            if (touch.phase == TouchPhase.Moved) //When a finger is moving along the screen
            {
                StartCoroutine(MovingFinger());

                //Debug.Log("touching screen " + touch.position);
                
                transform.position = Vector3.Lerp(transform.position, touchPos, 2 * Time.deltaTime); //Collider moves, following finger through interpolation, lagging behind it
            }

            if (touch.phase == TouchPhase.Ended)
            {
                
                StopCoroutine(MovingFinger());
                breezeActive = false;
                transform.position = initialPos;
            }

        }
    }

    IEnumerator MovingFinger()
    {
        if (Input.touchCount > 0)
        {
            breezeActive = true;
            
            yield return new WaitForSeconds(0.5f);

            breezeActive = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 direction = collision.contacts[0].point - transform.position;

        direction = direction.normalized;

        if (collision.rigidbody && collision.gameObject.tag == "Player")
        {

            collision.rigidbody.AddForce(direction * pushForce, ForceMode.Impulse);
        }

    }

    /*IEnumerator PushFlowerTime()
    {
        yield return new WaitForSeconds(2f);
        pushingFlower = true;
        yield return new WaitForSeconds(1);
        pushingFlower = false;

    }*/
}
