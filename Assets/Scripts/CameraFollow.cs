using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public ParallaxScroll parallax;
    private float distanceToTargetx=0;
    private float distanceToTargety = 3.5f;
    public float gooddistancex;
    public float gooddistancey;
    // Use this for initialization
    // Update is called once per frame
    void Update()
    {
        float distanceX= distanceToTargetx- transform.position.x + target.transform.position.x;
        float distanceY = distanceToTargety - transform.position.y + target.transform.position.y;
        Vector3 newCam = transform.position;
        newCam.x += distanceX/ gooddistancex;
        newCam.y += distanceY/ gooddistancey;
        transform.position = newCam;
        parallax.offset = transform.position.x;
    }
}

