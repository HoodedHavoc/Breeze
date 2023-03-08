using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTree : MonoBehaviour
{
    float treeSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Awake()
    {
        treeSpeed = OrbSpawner.speedMaster * 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * treeSpeed * Time.deltaTime);
    }
}
