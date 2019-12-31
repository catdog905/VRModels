using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * 0.1f;
        float y = Input.GetAxis("UpDown") * 0.1f; 
        float z = Input.GetAxis("Vertical") * 0.1f;

        if (Input.GetMouseButton(1))
        {
            float rx = Input.GetAxis("Mouse Y") * 2.0f;
            float ry = Input.GetAxis("Mouse X") * 2.0f;

            Vector3 rot = transform.eulerAngles;
            rot.x -= rx;
            rot.y += ry;
            transform.eulerAngles = rot;
        }
        if (Input.GetMouseButton(2))
        {
            x -= Input.GetAxis("Mouse X") * 0.1f;
            y -= Input.GetAxis("Mouse Y") * 0.1f;
        }
        z += Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(x, y, z);
    }
}
