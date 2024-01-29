using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraZoomOut : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "Enter")
        {
            SoundManager.Instance.AdmireParalax();

            if (collision.CompareTag("Player")) cam.Priority = 20;
        }
        else
        {
            if(collision.CompareTag("Player")) cam.Priority = 0;
            SoundManager.Instance.AdmireParalaxN();
        }

    }
}
