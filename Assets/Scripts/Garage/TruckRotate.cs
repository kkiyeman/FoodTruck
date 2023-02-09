using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckRotate : MonoBehaviour
{
    private float speed = 3f;
    public GameObject truck;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
        }
    }
}