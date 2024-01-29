using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private IsGrounded isGroundedScript;
    private PlayerInput _playerInputActions;
    private PlayerAnimatorController playerAnimatorController;
    private CameraFOV camScript;
    [SerializeField] GameObject pointsScript;
    [SerializeField] PlayerDeathTemp deadS;


    //Private Vars
    private bool holdingSpace;
    private bool haveJumped;
    public bool canRotate, isRotating;


    public int rotationScore;
    float timer;
    private bool checkAirTime;




    //for tester
    [Header("Valor comun entorno a 1000")]
    [SerializeField ]private float jumpForce;
    [Header("Velocidad de rotacion causada por el jugador")]
    [SerializeField] private float userRotationSpeed;
    [Header("Velocidad de rotacion tras rotacion jugador")]
    [SerializeField] private float automaticRotationSpeed;



    //m,ierda
    public int cont;
    private void Start()
    {
        //Asignacion valores
        userRotationSpeed = 200f;
        automaticRotationSpeed = -75f;
        jumpForce = 1000f;


        //Jump
        _playerInputActions = GetComponent<PlayerInput>();
        GetComponent<PlayerInput>().enabled = true;
        _playerInputActions.actions["Jump"].Enable();
        _playerInputActions.actions["Jump"].canceled += Jump_canceled;
        _playerInputActions.actions["Jump"].started += Jump_started;
        //
        jumpForce = 1000f;
        isGroundedScript = GetComponent<IsGrounded>();
        rb = GetComponent<Rigidbody2D>();
        camScript = GetComponent<CameraFOV>();
        playerAnimatorController = GetComponent<PlayerAnimatorController>();

    }
    void Update()
    {
       
        


    }

    private void FixedUpdate()
    {
        JumpRotation();
        CheckAirTimeV();
    }
    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        holdingSpace = false;
        //Debug.Log("CANCELED");
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        SoundManager.Instance.StopIdle();
        playerAnimatorController.OnJump();
        holdingSpace = true;
        haveJumped = true;
        if (rb != null) Invoke(nameof(CheckIfHaveJumped), 0.1f);
        //if (rb != null) Invoke(nameof(CheckIfStillGrounded), 0.4f);
        //Jump
        if (rb != null) if (isGroundedScript.isGrounded) rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        if (rb != null) if (isGroundedScript.isGrounded) rb.AddForce(transform.right * jumpForce / 2, ForceMode2D.Impulse);
    }
    /*
    private void CheckIfStillGrounded()
    {
        if (!isGroundedScript.isGrounded)
        {
            camScript.StartCoroutine("IncreaseJumpFov");
            InvokeRepeating("CheckWhenbackToGrounded", 0, 0.2f);
        }

    }
    private void CheckWhenbackToGrounded()
    {
        if (isGroundedScript.isGrounded)
        {
            camScript.StartCoroutine("DecreaseJumpFov");
            CancelInvoke();
        }
    }
    */
    private void CheckIfHaveJumped()
    {

        if (holdingSpace)
        {
            canRotate = true;
            checkAirTime = true;
        }
        if (isGroundedScript.isGrounded)
        {
            canRotate = false;
            haveJumped = false;
        }
    }



    private void JumpRotation()
    {

        if (isGroundedScript.isGrounded)
        {
            canRotate = false;
            CheckPoints();

            isRotating = false;
        }
            



        if (canRotate)
        {
            if (holdingSpace)
            {
                rb.angularVelocity = userRotationSpeed;
                rotationScore++;
                isRotating = true;
            }
            if (!holdingSpace && haveJumped)
            {
                rb.angularVelocity = automaticRotationSpeed;
                isRotating = false;
            }
        }

    }

    private void CheckPoints()
    {
        checkAirTime = false;
        timer = 0f;
        rotationScore = 0;
        cont = 0;


    }


    private void CheckAirTimeV()
    {
        if (checkAirTime && !deadS.dead)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                pointsScript.GetComponent<DistanceCalculator>().AddPoints(5);
                timer = 0;
            }
        }

        if (rotationScore >= 85 && cont == 0)
        {
            pointsScript.GetComponent<DistanceCalculator>().AddPoints(50);
            cont++;
        }
        if(rotationScore >= 170 && cont == 1)
        {
            pointsScript.GetComponent<DistanceCalculator>().AddPoints(200);
            cont++;
        }
    }

}
