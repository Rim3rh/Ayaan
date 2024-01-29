using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] Transform groundCheck1, groundCheck2, groundCheck3;
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;

    private void Update()
    {

        if(Physics2D.OverlapCircle(groundCheck1.position, groundRadius, groundLayer)
            || Physics2D.OverlapCircle(groundCheck2.position, groundRadius, groundLayer)
            || Physics2D.OverlapCircle(groundCheck3.position, groundRadius, groundLayer))
        {
            isGrounded = true;
        } else isGrounded = false;
    }

}
