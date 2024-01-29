using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSpeedBoost : MonoBehaviour
{
    private bool isBoosted;
    private Rigidbody2D rb;
    private PlayerMovement pMov;
    private PlayerInput _playerInputActions;
    private IsGrounded isGroundedScript;


    

    private float addedSpeed, timeOfBoost, boostSpeed;
    // Start is called before the first frame update
    void Start()
    {
        addedSpeed = 20f;
        timeOfBoost = 6f;
        boostSpeed = 1000f;

        pMov = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        isGroundedScript = GetComponent<IsGrounded>();

    }



    public void SpeedBoostP()
    {
       // GetComponent<Button>().interactable = false;
        if (rb != null) StartCoroutine(SpeedBoost(addedSpeed, timeOfBoost, boostSpeed));
    }


    private IEnumerator SpeedBoost(float addedSpeed, float timeOfFade, float speedBoost)
    {

        if(isGroundedScript.isGrounded)
        {
            SoundManager.Instance.Boost();
            //Debug.Log("GOLA");
            isBoosted = true;
            pMov.currentMaxVel = pMov.maxVel + addedSpeed;
            rb.AddForce(Vector2.right * speedBoost, ForceMode2D.Force);
            //rb.AddForce(Vector2.down * speedBoost * 2, ForceMode2D.Force);

            for (int i = 0; i < timeOfFade * 16; i++)
            {
                pMov.currentMaxVel = pMov.currentMaxVel - addedSpeed / (timeOfFade * 16);
                yield return new WaitForSeconds(timeOfFade / 100);
            }
            pMov.currentMaxVel = pMov.maxVel;
            isBoosted = false;

        }

    }
}
