using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMapCubeMovement : MonoBehaviour
{
    [SerializeField] private float beginTime;
    private Animation animationCube;
    private bool hasPlayed = false;

    void Start()
    {
        animationCube = GetComponent<Animation>();
        if (gameObject.tag == "CubePortal") {
            beginTime = 5;
            animationCube.wrapMode = WrapMode.Once;
        } else {
            beginTime = BeginTime();
        }
    }

    void Update() {
        if((!hasPlayed) && (Time.realtimeSinceStartup > beginTime)) {
            hasPlayed = true;
            animationCube.Play();
        }
    }

    public float BeginTime() {
        return Random.Range(0f,10f);
    }
    
}
