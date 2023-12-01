using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {
    private Animator animator;
    bool Close = false;
    AudioSource TrapS;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        TrapS = GetComponent<AudioSource>();
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (!Close)
        {
            animator.SetBool("Close", true);
            Close = true;
            TrapS.Play(1);
        }
    }
    public bool GetClose() {
        return Close;
    } 
}
