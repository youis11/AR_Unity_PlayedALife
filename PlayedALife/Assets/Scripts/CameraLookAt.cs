using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Camera cam;
    public float x_speed;
    public float y_speed;

    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane)), Vector3.up);
        x = Input.GetAxis("Mouse X") * x_speed * Time.deltaTime;
        y = Input.GetAxis("Mouse Y") * x_speed * Time.deltaTime;

        transform.Rotate(0, x, 0);
        cam.transform.Rotate(-y, 0, 0);
    }
}
