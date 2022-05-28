using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositionHandler : MonoBehaviour
{
    public Vector3 CursorPosition { get; private set; } = Vector3.zero;

    void Update() 
    {
        //Get mouse position
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            CursorPosition = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
        }
    }
}
