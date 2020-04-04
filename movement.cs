using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public CharacterController2D controller;

    private int tal = 0;

    public float runSpeed = 40f;
    public Animator animes;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

  
    void Update()
    {
  

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animes.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animes.SetBool("isjumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animes.SetBool("iscrunching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animes.SetBool("iscrunching", false);
        }

    }

    // takka up demanta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("mony"))
        {
            
            other.gameObject.SetActive(false);
            tal += 1;
            Debug.Log(tal);


        }
    }

    void FixedUpdate()
    {
        // Hreyfa persónunna
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
   public void OnLanding ()
    {
        animes.SetBool("isjumping", false);
    }
  
}