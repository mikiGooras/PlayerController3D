using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// first person camera controller
/// position of orientatin gameobject need to be reset position in player gameobject 
/// </summary>
public class FirstPersonCamera : MonoBehaviour
{
    public float sensX = 350, sensY = 350;// sensitiveness of mouse or joystic 
    public Transform orientation; //variable to holde position of player gameobject 
    float xRotation, yRotation, mouseX, mouseY;



    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
         mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
         mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
    }

    private void Update()
    {
        
        RotateCamera(mouseX, mouseY);
    }
    //rotate camera and a player
    void RotateCamera(float x,float y)
    {
        yRotation += x;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
