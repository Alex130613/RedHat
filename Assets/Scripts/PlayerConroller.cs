using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour {

    public float SpeedTrans = 5;
    public float horizontalMax;
    private Animator animator;
    private bool RightNow;
    public bool turn;
    AudioSource WalkSound;
    
    public Transform groundCheckTransform1;
    public Transform groundCheckTransform2;
    public LayerMask groundCheckLayerMask;
    double y;
    bool isJump = false;
    Rigidbody rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        WalkSound = GetComponent<AudioSource>();
        turn = false;
        rb = GetComponent<Rigidbody>();
        WalkSound.Play(0);
    }
    void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
        horizontalMax = Input.GetAxis("Horizontal") * SpeedTrans * Time.deltaTime;
        if (horizontalMax != 0)
            {
               animator.SetBool("RightNow", (horizontalMax > 0));
            }
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Walk", (horizontalMax != 0));
                if ((horizontalMax != 0)) WalkSound.UnPause();
                else WalkSound.Pause();
                }
        }
        else {
            WalkSound.Pause();
            CheckJump();
        }
        y = (double)rb.velocity.y;
        animator.SetBool("Up", (y > 0.1));
        if (!turn)
        {
            transform.Translate(0, 0, Mathf.Abs(horizontalMax));
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PushObject"))
        {
            animator.SetBool("Push", true);
        }
    }
    void OnTriggerExit(Collider other)
{
    if (other.gameObject.CompareTag("PushObject"))
    {
        animator.SetBool("Push", false);
    }
}
void CheckJump() {
        bool Check1 = Physics.Raycast(transform.position, Vector3.down, 0.01f, groundCheckLayerMask);
        bool Check2 = Physics.Raycast(groundCheckTransform1.position, Vector3.down, 0.01f, groundCheckLayerMask);
        bool Check3 = Physics.Raycast(groundCheckTransform2.position, Vector3.down, 0.01f, groundCheckLayerMask);
        isJump = !(Check1 ||Check2 ||Check3 );
        animator.SetBool("Jump", isJump);
    }
    public void Jump(){rb.velocity = new Vector3(0, 6, 0);
                isJump = true;
    }
}
