using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationner : MonoBehaviour
{

    [SerializeField] private CursorPositionHandler cursorPositionHandler;

    void Update()
    {   
        Rotate();
    }

    private void Rotate() 
    {
        Vector3 cursorPosition = cursorPositionHandler.CursorPosition;

        //Player's rotation
        Vector3 dir = cursorPosition - transform.position; //The direction
        Quaternion lookRotation = Quaternion.LookRotation(dir); //Represents the rotation
        Vector3 rotation = lookRotation.eulerAngles;  //Convert Rotation to utilizable rotation
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);   //We apply the rotation on the object to rotate
    }
}
