using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    [SerializeField] float zoomSpeedY = 3f;
    [SerializeField] float zoomSpeedZ = 3f;

    [SerializeField] float scrollSpeedHorizontal = 1f;
    [SerializeField] float scrollSpeedVertical = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel") * -1;
        transform.position += new Vector3(0f,mouseWheel * zoomSpeedY * Time.deltaTime,mouseWheel * zoomSpeedZ * Time.deltaTime);

        transform.position += new Vector3(Input.GetAxis("Horizontal") * scrollSpeedHorizontal * Time.deltaTime,0f,Input.GetAxis("Vertical") * scrollSpeedVertical * Time.deltaTime);
    }
}
