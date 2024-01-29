using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private GameObject playerAnim;
    //[SerializeField] private GameObject player;
    private Animator anim;
    private IsGrounded isGroundedScript;
    private bool isJumping;

    private void Start()
    {

        anim = playerAnim.GetComponent<Animator>();
        isGroundedScript = GetComponent<IsGrounded>();
    }



    public void OnJump()
    {
        anim.SetInteger("JumpState", 1);


        if(!isJumping) Invoke(nameof(CheckJumpState), 0.4f);
    }

    private void CheckJumpState()
    {
        isJumping = true;


        if (isGroundedScript.isGrounded)
        {
            anim.SetInteger("JumpState", 0);
            isJumping = false;
        }
        else
        {
            InvokeRepeating("prueba", 0, 0.05f);
            if (GetComponent<PlayerJump>().isRotating)
            {
                anim.SetInteger("JumpState", 3);
               // Debug.Log("GAIOJS");
                
            }

        }
    }

    private void prueba()
    {
        //Debug.Log("GOLA");
        if (isGroundedScript.isGrounded)
        {
            anim.SetInteger("JumpState", 0);
            isJumping = false;
            SoundManager.Instance.StartIdle();
            CancelInvoke();
        }
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speed+1")) anim.SetBool("PlayerSpeed", true);
        if (collision.CompareTag("Speed-1")) anim.SetBool("PlayerSpeed", false);
    }


    public void EndGame()
    {
        Time.timeScale = 0;
    }
}
