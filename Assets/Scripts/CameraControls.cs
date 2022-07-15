using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField]
    private Transform cameraCenter;
    [SerializeField]
    [Range(1,8)]
    private int rotationSpeed = 3;
    private void Update()
    {
        this.gameObject.transform.LookAt(cameraCenter);
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(cameraCenter.position, Vector3.up, (float)rotationSpeed/10*-1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(cameraCenter.position, Vector3.up, (float)rotationSpeed / 10);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(cameraCenter.position, transform.TransformDirection(Vector3.right), (float)rotationSpeed / 10 * -1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(cameraCenter.position, transform.TransformDirection(Vector3.right), (float)rotationSpeed / 10);
        }
    }
}
