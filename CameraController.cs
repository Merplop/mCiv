using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 13;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        if (scroll < 0) {
            cam.orthographicSize -= scroll * 10;
            speed -= scroll * 10;
        } else if (scroll > 0 && cam.orthographicSize > 2) {
            cam.orthographicSize -= scroll * 10;
            speed -= scroll * 10;
        }

        if (hori != 0 || vert != 0) {
            pos.x += hori * Time.deltaTime * speed;
            pos.y += vert * Time.deltaTime * speed;
        }

        transform.position = pos;
    }

    public void centerOnHex(Vector2 p) {
        transform.position = p;
    }
}
