using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity: MonoBehaviour
{
    public GameObject[] objects;
    public Vector3 speed;
    public Vector3 force;
    float mass;
    public float G=20.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
        rb.velocity = speed;
        objects = GameObject.FindGameObjectsWithTag("Gravity");
    }

    void FixedUpdate()
    {
        force = new Vector3(0, 0, 0);
        foreach (GameObject attractingObject in objects)
            if (attractingObject != this.gameObject)
                GetAttractingForce(attractingObject);
        rb.AddForce(force);
    }
    void GetAttractingForce(GameObject attractingObject)
    {
        Vector3 r = attractingObject.transform.position - this.transform.position;
        Vector3 e = r.normalized;
        float r2 = r.sqrMagnitude;

        force += e * G * attractingObject.GetComponent<Rigidbody>().mass * mass / r2;
        
    }
}
