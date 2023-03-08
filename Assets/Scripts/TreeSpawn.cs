using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public GameObject spawnedTree;

    public Transform spawnPoint;

    //int randomIndex;

    //int randomRotation;

    // Update is called once per frame
    void Update()
    {
        //randomIndex = Random.Range(0, spawnedObjects.Length);

        //randomRotation = Random.Range()
    }

    private void Start()
    {
        //transform.position = spawnPoint.position;

        //Quaternion randomRot = new Quaternion(Random.Range(-1, 1), 1, 1);

        
        
    }

    private void Awake()
    {
        StartCoroutine(SpawnTree());

        //spawnedTree.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    IEnumerator SpawnTree()
    {
        
        Vector3 spawnPos = spawnPoint.position; //new Vector3(Random.Range(-3f, 4f) * 2, 0f, 15f);
        Instantiate(spawnedTree, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(3, 7));
        StartCoroutine(SpawnTree());
    }
}
