using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public float panSpeed = 30f;

    private float scrollSpeed = 5f;
    private float speed = 50f;

    private float minY = 10f;
    private float maxY = 100f;

    private float newMinY = -45.0f;
    private float newMaxY = 45.0f;

    public float sensX = 100.0f;
    public float sensY = 100.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

    public CharacterController controller;

    void Update()
    {
        if (Input.GetMouseButton(1)) 
        {
            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, newMinY, newMaxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
              
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;

        position.y -= 800 * scrollInput * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        this.transform.position = position;
    } 
}
