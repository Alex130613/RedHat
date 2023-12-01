using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DethController : MonoBehaviour {

    public GameObject GOv;
    private Animator animator;
    AudioSource WalkSound;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        WalkSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deth"))
        {
            GetComponent<PlayerConroller>().enabled = false;
            animator.SetBool("Deth", true);
            WalkSound.Pause();
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            if (!other.gameObject.GetComponent<TrapController>().GetClose())
            {
                GetComponent<PlayerConroller>().enabled = false;
                animator.SetBool("Deth", true);
                WalkSound.Pause();
            }
        }
    }
    public void End() {
        GOv.SetActive(true);
    }
    public void Continue() {
       Application.LoadLevel("Game");
    }
    public void Menu() {
        Application.LoadLevel("Menu");
    }
}
