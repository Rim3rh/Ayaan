using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CliftCameraTemp : MonoBehaviour
{

    private EnterZoneTemp enterZone;
    private ExitZoneTemp exitZone;
    CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        //Referencia a los colliders hijos.
        enterZone = transform.Find("EnterZone").gameObject.GetComponent<EnterZoneTemp>();
        exitZone = transform.Find("ExitZone").gameObject.GetComponent<ExitZoneTemp>(); ;
        //Reference to Camera
        cam = GetComponent<CinemachineVirtualCamera>();
        //nos subscribimos a los eventos de los hijos.
        enterZone.EnterZone += EnterZone_EnterZone;
        exitZone.ExitZone += ExitZone_ExitZone;
    }

    private void ExitZone_ExitZone()
    {
        cam.Priority = 0;
        Debug.Log("GOLA");
    }

    private void EnterZone_EnterZone()
    {
        cam.Priority = 10;
    }
}
