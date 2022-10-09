using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// First person camera offset
/// to use this you need to put
/// empty gameobject that transform value
/// are set like the one of camera (eyes)
/// this empty gameobject need to be part of player gameobject
/// In this case camera is not part of the player object but it is seperatet game object
/// </summary>
public class FirstPersonCameraOffset : MonoBehaviour
{
    public Transform CameraPosition;// position of player eyes
    void Update()
    {
        transform.position = CameraPosition.position;
    }
}
