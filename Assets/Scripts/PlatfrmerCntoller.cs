using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfrmerCntoller : MonoBehaviour {

    public GameObject Taget;
    public float speed;
    public Vector3 a;
    private Vector3 b;
    public int type = 1;
    private Animator animator;
    public bool IsStart=false;
    void Start() {
        b = transform.position;
        animator = GetComponent<Animator>();
    }
    void Update() {
        GetComponent<BoxCollider>().enabled = (Taget.transform.position.y > transform.position.y);
        if (type == 2) {
            Vector3 pos = transform.position;
            Vector3 v;
            if (IsStart)
            { v = new Vector3((a.x - pos.x) / speed, (a.y - pos.y) / speed, (a.z - pos.z) / speed); }
            else { v = new Vector3((b.x - pos.x) / speed, (b.y - pos.y) / speed, (b.z - pos.z) / speed); }
            transform.Translate(v.x,v.y,v.z);
        }
    }
    public void Press(bool p) {
        if (type == 1) { animator.SetBool("ButtonPress", p); }
        if (type == 2) { IsStart = p; }
    }
}

