using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> planets = new List<GameObject>();

    [SerializeField]
    private float rotationSpeed;


    private void Update()
    {
        RotatePlanets();
    }

    private void RotatePlanets()
    {

    }
}
