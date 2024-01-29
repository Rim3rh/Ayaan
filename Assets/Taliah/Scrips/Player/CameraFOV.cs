using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    [SerializeField] float minFov;
    [SerializeField] float maxFov;
    public bool isJumping;
    public bool onEntry;

    //Components
    private Rigidbody2D rb;
    private CinemachineVirtualCamera cam;

    //References to other scripts
    private PlayerMovement playerMovement;
    private PlayerJump playerJump;
    void Start()
    {
        //Local vars
        minFov = 65;
        maxFov = 35;

        //Getting Components
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("MainVirtualCamera").GetComponent<CinemachineVirtualCamera>();

        //Getting Other scripts
        playerMovement = GetComponent<PlayerMovement>();
        playerJump = GetComponent<PlayerJump>();
    }

    void Update()
    {
        if(!isJumping && !onEntry) CameraFov();
    }


    private void CameraFov()
    {
        //Debug.Log("decrease");
        float p;
        //we calculate the size the camera will use depending on the speed, have minFov as min and maxFov as max
        p = Mathf.Abs(rb.velocity.x / playerMovement.maxVel * 100);
        if (p > 100) p = 100;
        cam.m_Lens.FieldOfView = minFov + (p * maxFov / 100);
        /*
        if (!GameManager.Instances.playing)
        {

        }
        */
    }




    public IEnumerator IncreaseJumpFov()
    {
        isJumping = true;
        //cam.m_Lens.FieldOfView = 100;
        if(cam.m_Lens.FieldOfView !<= 95)
        {
            for (int i = 0; i < cam.m_Lens.FieldOfView - 100; i++)
            {
                Debug.Log("HOAL");
                cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.2f;
                yield return new WaitForSeconds(0.01f);
                cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.2f;
                yield return new WaitForSeconds(0.01f);
                cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.2f;
                yield return new WaitForSeconds(0.01f);
                cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.2f;
                yield return new WaitForSeconds(0.01f);
                cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.2f;
                yield return new WaitForSeconds(0.01f);
            }
        }


        for (int i = 0; i < 100; i++)
        {
            Debug.Log("HOAL");
            cam.m_Lens.FieldOfView = cam.m_Lens.FieldOfView + 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(DecreaseJumpFov());
    }

    public IEnumerator DecreaseJumpFov()
    {
        
       // cam.m_Lens.FieldOfView = 120;

        for (int i = 0; i < 100; i++)
        {
            
            cam.m_Lens.FieldOfView -= 0.2f;
            yield return new WaitForSeconds(0.01f);
        }
        isJumping = false;
        playerJump.cont = 0;
    }



    public IEnumerator Entry()
    {
       onEntry = true;
        cam.m_Lens.FieldOfView = 65;
        for (int i = 0; i < 100; i++)
        {

            cam.m_Lens.FieldOfView += 0.2f;
            yield return new WaitForSeconds(0.02f);
        }
        onEntry = false;
    }
}
