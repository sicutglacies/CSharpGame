using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public float panSpeed = 30f;

    private float panBorderThickness = 10f;
    private bool movementFlag = true;
    private float scrollSpeed = 5f;

    private float minY = 10f;
        private float maxY = 100f;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))      
            movementFlag = !movementFlag;      
        
        if (!movementFlag)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
            
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;

        position.y -= 800 * scrollInput * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        this.transform.position = position;
    } 
}
