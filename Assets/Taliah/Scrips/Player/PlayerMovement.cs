using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private IsGrounded isGroundedScript;
    public PlayerDeathTemp deathtemp;

    [HideInInspector] public float currentMaxVel, maxVel;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGroundedScript = GetComponent<IsGrounded>();

        maxVel = 30f;
        currentMaxVel = maxVel;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
       
    }
    void Update()
    {
        Application.targetFrameRate = 60;
        //Debug.Log(currentMaxVel);
        if(!deathtemp.dead)
        {
            GravityMultiplier();
            SpeedLimiter();
        }




        //  if(rb.velocity.x <= 0) deathtemp.EndGame();
        // Debug.Log(currentMaxVel);

    }
    private void GravityMultiplier()
    {
        //when ur going down, gravity will be 20, if ur going up, or falling without tuching ground, gravity will be 1.
            switch (rb.velocity.y)
            {

                case > 0:
                    //1.3s
                    rb.gravityScale = 3f;

                    break;
                case < 0:

                    if (isGroundedScript.isGrounded) rb.gravityScale = 20;
                    else rb.gravityScale = 3f;

                    break;
            }

    }
    private void SpeedLimiter()
    {
        //if u go past maxVel, ur speed = to maxVel, if u go under 0, ur speed = 0.
        if (Mathf.Abs(rb.velocity.x) >= currentMaxVel)          
        {
            //Debug.Log(currentMaxVel + rb.velocity.x);
            rb.velocity = new Vector2( currentMaxVel, rb.velocity.y);
        }




    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedLimit"))
        {
            currentMaxVel = maxVel + 10;
        }

        if (collision.CompareTag("SpeedSubstracter"))
        {
            StartCoroutine(ReduceSpeed());
        }


    }


    public IEnumerator ReduceSpeed()
    {

        for (int i = 0; i < 200; i++)
        {
            currentMaxVel = maxVel - 0.5f;
            yield return new WaitForSeconds(0.01f);
        }
    }
     public IEnumerator Entry()
     {
        
        currentMaxVel = 10;
        for (int i = 0; i < 300; i++)
        {
            
            currentMaxVel += 0.05f;
            yield return new WaitForSeconds(0.01f);
           // Debug.Log(currentMaxVel);
        }
        currentMaxVel = maxVel;
        //Debug.Log(currentMaxVel);
     }




}
