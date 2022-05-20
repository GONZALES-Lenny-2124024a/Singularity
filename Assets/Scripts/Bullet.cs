using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float countdownBeforeDeath = 5f;
    public float countdown;

    // Update is called once per frame  
    void Update()
    {
        if (countdown >= countdownBeforeDeath) {
            Debug.Log("DEAD");
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        countdown += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        transform.rotation = Quaternion.Inverse(transform.rotation);
        /*
        Quaternion newRotation = transform.rotation;
        newRotation.y *= -1;
        transform.rotation = newRotation;*/
    }
}
