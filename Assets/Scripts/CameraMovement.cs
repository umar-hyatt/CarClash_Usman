using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform car;
    public Vector3 offset;
    void Update()
    {
        transform.position = car.position + offset;
    }
}
