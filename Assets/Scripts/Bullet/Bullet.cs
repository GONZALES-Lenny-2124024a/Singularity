using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    [SerializeField] private GameObject particleHit;

    [Header("Stats")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private int bulletLife = 3;


    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;    //Initialize the speed of the bullet
    }

    // Update is called once per frame  
    void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collisionObject) {
        addParticle(collisionObject);

        if(collisionObject.gameObject.tag == "Player") {
            Destroy(collisionObject.gameObject);
        }

        Bounce(collisionObject.contacts[0].normal); //Get the normal of the collisioObjects and call Bounce's function
        decrBulletLife();
    }

    void Bounce(Vector3 collisionNormal) {
        Vector3 direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal); //Get the direction of the reflection
        rb.velocity = direction * speed;
    }

    void decrBulletLife() {
        --bulletLife;
        if (bulletLife <= 0) {
            Destroy(gameObject);
        }
    }

    void addParticle(Collision collisionObject) {
        #region particle's Position and Rotation
        ContactPoint contact = collisionObject.contacts[0];
        Vector3 pos = contact.point;
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        #endregion
        
        GameObject particle = (GameObject) Instantiate(particleHit, pos, rot);
        Destroy(particle, 0.5f);
    }
}
