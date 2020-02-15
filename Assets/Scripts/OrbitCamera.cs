using UnityEngine;
using System.Collections;

// maintains position offset while orbiting around target

public class OrbitCamera : MonoBehaviour {
	[SerializeField] private Transform target;

    public Vector3 offset;
    public float sensitivity = 3; // чувствительность мышки
    public float top_limit = 80; // ограничение вращения по Y
    public float bottom_limit = 10; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    public float move_speed = 50; // мин. увеличение
    private float X, Y;

    void Start()
    {
        top_limit = Mathf.Abs(top_limit);
        if (top_limit > 90) top_limit = 90;
        bottom_limit = Mathf.Abs(bottom_limit);
        if (bottom_limit > 90) bottom_limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
            offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity * -1;
            Y = Mathf.Clamp(Y, 10, 90);
            transform.localEulerAngles = new Vector3(Y, X, 0);
            transform.position = transform.localRotation * offset + target.position;
        }
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float old_height = transform.position.y;
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.Translate(direction * move_speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, old_height, transform.position.z);
        }
    }

    
}
