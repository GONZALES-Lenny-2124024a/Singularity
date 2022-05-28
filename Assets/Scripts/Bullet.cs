using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float countdownBeforeDeath = 5f;
    private float countdown = 0f;

    [SerializeField] private float speed = 20f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;    //Initialize the speed of the bullet
    }

    // Update is called once per frame  
    void Update()
    {
        if (countdown >= countdownBeforeDeath) {    //The bullet dies after 5 seconds
            Destroy(gameObject);
        }
        countdown += Time.deltaTime;

        lastFrameVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collisionObject) {
        Bounce(collisionObject.contacts[0].normal); //Get the normal of the collisioObjects and call Bounce's function
    }

    void Bounce(Vector3 collisionNormal) {
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal); //Get the direction of the reflection
        rb.velocity = direction * speed;
    }
}
