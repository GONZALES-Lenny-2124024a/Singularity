using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{

    public float speed = 5f;
    private Vector3 mousePos;
    // Update is called once per frame
    void Update()
    {   

        //Get the mouse position
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            mousePos = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
        }
        Vector3 dir = mousePos - transform.position; //The direction

        //Keys
        if(Input.GetKey("z")) {
            transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        }
    }
}
