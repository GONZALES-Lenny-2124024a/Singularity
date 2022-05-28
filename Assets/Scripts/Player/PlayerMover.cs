using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CursorPositionHandler cursorPositionHandler;

    [Header("Stats")]
    [SerializeField] private float speed = 5f;

    void Update()
    {   
        if(Input.GetKey(KeyCode.Z))
        {
            Move();
        }
    }

    private void Move() 
    {
        Vector3 cursorPosition = cursorPositionHandler.CursorPosition;
        transform.position = Vector3.MoveTowards(transform.position, cursorPosition, speed * Time.deltaTime);
    }
}
