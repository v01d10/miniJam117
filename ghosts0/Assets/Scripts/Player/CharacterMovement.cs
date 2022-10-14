using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    public float speed = 4;

    Vector3 lookPos;

    public static bool CanPort = true;
    public static bool outside;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement * speed / Time.deltaTime);

        if(GameManager.Instance.State == GameState.Day)
            AnimatePlayerDay(); 
        else if(GameManager.Instance.State == GameState.Night)
        {
            AnimatePlayerNight();

            if(Input.GetMouseButtonDown(0))
                animator.SetTrigger("PlayerShot");
        }
    }

    void AnimatePlayerDay()
    {
        animator.SetLayerWeight(0, 1);
        animator.SetLayerWeight(1, 0);
        if(Input.GetKey("w"))
        {
            animator.SetBool("IsRunning", true);
        }
        else if(Input.GetKey("a"))
        {
            animator.SetBool("IsRunning", true);
        }
        else if(Input.GetKey("s"))
        {
            animator.SetBool("IsRunning", true);
        }
        else if(Input.GetKey("d"))
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    void AnimatePlayerNight()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetLayerWeight(0, 0);
        if(Input.GetKey("w"))
        {
            animator.SetBool("GunRunning", true);
        }
        else if(Input.GetKey("a"))
        {
            animator.SetBool("GunRunning", true);
        }
        else if(Input.GetKey("s"))
        {
            animator.SetBool("GunRunning", true);
        }
        else if(Input.GetKey("d"))
        {
            animator.SetBool("GunRunning", true);
        }
        else
        {
            animator.SetBool("GunRunning", false);
        }

    }
}
