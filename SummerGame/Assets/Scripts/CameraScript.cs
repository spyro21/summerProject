using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float speed = 4f;
    private Transform target;
    private Vector3 distanceFromVec;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //cameraFollowCurrentTarget();
    }

    void cameraFollowCurrentTarget() {
        distanceFromVec = transform.position - target.position;
        float distanceFrom = distanceFromVec.magnitude;
        if(distanceFrom <= 2) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, (speed / 2) * Time.deltaTime);
        }  else if( distanceFrom >= 5) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * 2) * Time.deltaTime);
        } else {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
