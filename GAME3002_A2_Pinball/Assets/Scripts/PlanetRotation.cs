using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField]
    [Range(-1.5f, 1.5f)]
    private float rotationSpeedX;

    [SerializeField]
    [Range(-1.5f, 1.5f)]
    private float rotationSpeedY;

    [SerializeField]
    [Range(-1.5f, 1.5f)]
    private float rotationSpeedZ;

    Rigidbody mPlanetRB;

    private void Start()
    {
        mPlanetRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotatePlanet();
    }

    private void RotatePlanet()
    {
        mPlanetRB.transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
    }
}