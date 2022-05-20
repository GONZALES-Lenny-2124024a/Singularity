using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    private Vector3 mousePos;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float countdownBetweenShoot = 2f;
    private float countdownActual;

    void Start() {
        countdownActual = countdownBetweenShoot;    //The player can shots immediately
    }

    // Update is called once per frame
    void Update()
    {   

        //Get mouse position
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            mousePos = new Vector3 (hit.point.x, hit.point.y, hit.point.z);    //transform.position.y
        }

        //Player's rotation
        Vector3 dir = mousePos - transform.position; //The direction
        Quaternion lookRotation = Quaternion.LookRotation(dir); //Represents the rotation
        Vector3 rotation = lookRotation.eulerAngles;  //Convert Rotation to utilizable rotation
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);   //We apply the rotation on the object to rotate

        countdownActual += Time.deltaTime;  //Countdown between two shots
        //--------------------Keys

        if(Input.GetKey("z")) {     //Move
            transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {   //Shoot            
            if(countdownActual >= countdownBetweenShoot) {   //Countdown between two shots
                GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                countdownActual = 0f;
            }
        }
    }
}
