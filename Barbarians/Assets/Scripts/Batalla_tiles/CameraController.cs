using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 37)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -31)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > -22)
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < 15)
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (GetComponent<Camera>().orthographicSize > 5)
            {
                GetComponent<Camera>().orthographicSize -= 1;
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (GetComponent<Camera>().orthographicSize < 20)
            {
                GetComponent<Camera>().orthographicSize += 1;
            }
        }
    }
}
