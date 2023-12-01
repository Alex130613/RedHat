using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour {
    bool push=false;
    int i = 0;
    public float z;
    public GameObject Target;
    void Start() { z = transform.position.z;
    }
    void Update() {
        if (push)
        {
            if (i < 25){ transform.Translate(0, 0, -0.003f);
                ++i;
            }
        }
        else {
            i = 0;
            if (transform.position.z > z) {
                transform.Translate(0, 0, 0.003f);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        push = true;
        Target.GetComponent<PlatfrmerCntoller>().Press(true);
    }
    void OnTriggerExit(Collider other)
    {
        push = false;
        Target.GetComponent<PlatfrmerCntoller>().Press(false);
    }

}