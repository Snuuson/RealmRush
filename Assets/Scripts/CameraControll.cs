using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    [SerializeField] float zoomSpeed = 50f;

    [SerializeField] float panSpeed = 50f;

    
    [SerializeField] float rotationSpeed = 3.5f;
    [SerializeField] float sidePanPercent = 0.05f;
    bool isRotating = false;
    Vector3 rotateStartMousePosition = new Vector3();

    Quaternion cameraStartRotation = new Quaternion();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Pan();
        Zoom();
        Rotate();
    }

    private void Zoom()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel") ;
        transform.Translate(transform.forward * mouseWheel * zoomSpeed * 10 * Time.deltaTime,Space.World);
    }
    
    private void HorizontalKeyboardPan()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            Vector3 right = transform.right;
            right.y = 0;
            right.Normalize();
            PanInDirection(right);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            Vector3 left = transform.right * -1;
            left.y = 0;
            left.Normalize();
            PanInDirection(left);
        }
    }
    
    private void verticalKeyboardPan()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            Vector3 up = transform.up;
            up.y = 0;
            up.Normalize();
            PanInDirection(up);
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            Vector3 down = transform.up * -1;
            down.y = 0;
            down.Normalize();
            PanInDirection(down);
        }
    }

    private void Pan()
    {
        KeyboardPan();
        if(!isRotating)
        {
            MousePan();
        }
        
    }
    private void KeyboardPan()
    {
        HorizontalKeyboardPan();
        verticalKeyboardPan();
    }
    private void MousePan()
    {
        HorizontalMousePan();
        VerticalMousePan();
    }

    private void PanInDirection(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * panSpeed,Space.World);
    }

    private void HorizontalMousePan()
    {
        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();
        Vector3 left = right * - 1;
        
        
         if ( Input.mousePosition.x >= Screen.width * (1 - sidePanPercent))
         {
            PanInDirection(right);
         }
         if ( Input.mousePosition.x <= Screen.width * (0 + sidePanPercent))
         {
            PanInDirection(left);
         }
    }

    private void VerticalMousePan()
    {
        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 back = forward * -1;

        if ( Input.mousePosition.y >= Screen.height * (1 - sidePanPercent))
         {
             PanInDirection(forward);
         }
         if ( Input.mousePosition.y <= Screen.height * (0 + sidePanPercent))
         {
             PanInDirection(back);
         }
    }

    private void Rotate()
    {
        if(Input.GetMouseButtonDown(2) && !isRotating)
        {
            
            isRotating = true;
            rotateStartMousePosition = Input.mousePosition;
            cameraStartRotation = transform.rotation;
        }

        if(Input.GetMouseButtonUp(2))
        {
            isRotating = false;
        }

        if(isRotating)
        {

            
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotationSpeed, Input.GetAxis("Mouse X") * rotationSpeed, 0));
            float X = transform.rotation.eulerAngles.x;
            float Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }


    }
}
