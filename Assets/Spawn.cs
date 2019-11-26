using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public GameObject starPrefab;
    public GameObject planetPrefab;
    public float maxRadius=200;
    public float maxVelocity = 3;
    public int maxMass = 100;
    public int minMass = 50;

    void Awake()
    {
        GameObject[] stars = new GameObject[3];
        for(int i=0;i<3;i++)
        {
            stars[i]=Instantiate(starPrefab, Random.insideUnitSphere * maxRadius, new Quaternion());
            stars[i].GetComponent<Gravity>().speed = Random.insideUnitSphere * maxVelocity;
            Light light=stars[i].GetComponent<Light>();
            light.color = Color.HSVToRGB(Random.Range(0f, 1), Random.Range(0.8f, 1), Random.Range(0.8f, 1));
            light.intensity = Random.Range(4,10);
            light.range = Random.Range(10, 20);
            stars[i].GetComponent<Rigidbody>().mass = Random.Range(minMass, maxMass);
        }
        GameObject planet = Instantiate(planetPrefab, Random.insideUnitSphere * maxRadius/2, new Quaternion());
        planet.GetComponent<Gravity>().speed = Random.insideUnitSphere * maxVelocity/2;
    }

    void Update()
    {
        
    }
}
