using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOrbs : MonoBehaviour
{
    float orbSpeed = 0;

    private void Awake()
    {
        //OrbSpawner speed = spawner.GetComponent<OrbSpawner>();
        orbSpeed = OrbSpawner.speedMaster;
        Destroy(gameObject, 7);
    }
    void Update()
    {

        transform.Translate(Vector3.forward * orbSpeed * Time.deltaTime);

        transform.Rotate(0, 0, 40 * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            //Debug.Log("hit Dead Zone");
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            Pickup(other);
            Destroy(gameObject);
        }
    }

    private void Pickup(Collider player)
    {
        Debug.Log("collected 1 orb");
        PlayerFlowerControl collecting = player.GetComponent<PlayerFlowerControl>();
        collecting.pointCounter += 1;
    }
}
