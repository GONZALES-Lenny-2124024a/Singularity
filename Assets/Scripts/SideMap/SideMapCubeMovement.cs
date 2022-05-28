using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMapCubeMovement : MonoBehaviour
{
    private float beginTime;
    private Animation animation;
    private bool hasPlayed = false;

    void Start()
    {
        animation = GetComponent<Animation>();
        if (gameObject.tag == "CubePortal") {
            beginTime = 5;
            animation.wrapMode = WrapMode.Once;
        } else {
            beginTime = BeginTime();
        }
    }

    void Update() {
        if((!hasPlayed) && (Time.realtimeSinceStartup > beginTime)) {
            hasPlayed = true;
            animation.Play();
        }
    }

    public float BeginTime() {
        return Random.Range(0f,10f);
    }
    
}
