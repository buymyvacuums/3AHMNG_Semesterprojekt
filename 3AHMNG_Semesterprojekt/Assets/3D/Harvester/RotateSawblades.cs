using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSawblades : MonoBehaviour
{
    //public Vector3 rotationSpeed = new Vector3(100, 0, 0); // degrees per second
    void Update()
    {
        transform.Rotate(360 * Time.deltaTime, 0, 0, Space.Self); //Rotate around the x-Achse 360° per Second

    }
}