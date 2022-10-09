using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// to use script below
/// drag it to cinemachine object in inspector
/// set the refeences to orientation, model and player GO
/// next set rotation speed hit play and go.  
/// </summary>

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]

    public Transform orientation, Player, PlayerModel;
    public Rigidbody rb;
    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        // rotate orientation 
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;


        // rotate player
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector3 InputDir = orientation.forward * VerticalInput + orientation.right * horizontalInput;



        if (InputDir != Vector3.zero)
        {
            PlayerModel.forward = Vector3.Slerp(PlayerModel.forward, InputDir.normalized, Time.deltaTime * rotationSpeed);
        }




    }


}
