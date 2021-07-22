using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotationScript : MonoBehaviour
{
    public float speed = 50.0f;

    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }
}
