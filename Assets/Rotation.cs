using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class Rotation : MonoBehaviour
{
    Transform self;
    public float omega = 10;
    Vector3 axis;

    void Start()
    {
        Random.InitState(DateTime.Now.Second);
        axis = Random.onUnitSphere;
        Vector3 relativePos = new Vector3(axis.z,axis.z,-axis.x-axis.y).normalized;
        self = GetComponent<Transform>();
        self.LookAt(self.position+relativePos);
    }

    void Update()
    {
        self.Rotate(axis, omega * Time.deltaTime, Space.World);
    }
}
