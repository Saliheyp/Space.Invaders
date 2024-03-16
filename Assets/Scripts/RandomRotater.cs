using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{
    Rigidbody rb;

    public int rotationSpeed =3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.angularVelocity = Random.insideUnitSphere*rotationSpeed;
    }
}
