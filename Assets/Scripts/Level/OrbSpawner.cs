using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{

    //public GameObject sunOrbs;

    public GameObject[] spawnedObjects;

    int randomIndex;

    float minimumTime = 0.3f;
    float maximumTime = 5.0f;

    public static float speedMaster = -1.0f;

    private void Awake()
    {
        StartCoroutine(SpawnOrbs());
    }

    // Update is called once per frame
    void Update()
    {

        randomIndex = Random.Range(0, spawnedObjects.Length);
        
        speedMaster += -0.3f * Time.deltaTime;

        if (maximumTime > 0.5f)
        {
            maximumTime -= 0.3f * Time.deltaTime;
        }
    }

    IEnumerator SpawnOrbs()
    {
        yield return new WaitForSeconds(Random.Range(minimumTime, maximumTime));
        Vector3 spawnPos = new Vector3(Random.Range(-2f, 3f), Random.Range(1f, 6f), 7f);
        GameObject instantiateObject = Instantiate(spawnedObjects[randomIndex], spawnPos, Quaternion.identity) as GameObject;
        //Debug.Log("spawned");

        StartCoroutine(SpawnOrbs());

    }
}
