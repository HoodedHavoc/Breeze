using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunrot : MonoBehaviour
{
    public float rotSpeed;

    void Update() => transform.Rotate(Vector3.up* (rotSpeed* Time.deltaTime));
}
