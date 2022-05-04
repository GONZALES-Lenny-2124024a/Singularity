using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMapCubeMovement : MonoBehaviour
{
    private float beginTime;
    private Animation animation;

    void Start()
    {
        beginTime = BeginTime();
        Debug.Log(beginTime);
        animation = GetComponent<Animation>();
    }

    void Update() {
        if(!animation.isPlaying) {
            if (Time.realtimeSinceStartup > beginTime) {
                animation.Play();
            }
        }
    }

    public float BeginTime() {
        return Random.Range(0f,10f);
    }
    
}
