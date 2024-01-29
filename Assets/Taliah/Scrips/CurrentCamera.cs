using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CurrentCamera : MonoBehaviour
{
    public GameObject cube;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {


        Vector3 cubeScale;

        cubeScale = new Vector3(( 21.36f / 6 * cam.orthographicSize), (12 / 6 * cam.orthographicSize), 1);
        cube.transform.localScale = cubeScale;
    }
    


    public CinemachineVirtualCamera CurrentCam()
    {
        CinemachineVirtualCamera liveCamera = this.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        return liveCamera;
    }
}
