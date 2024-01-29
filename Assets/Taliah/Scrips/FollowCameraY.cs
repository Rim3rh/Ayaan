using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraY : MonoBehaviour
{
    private GameObject cam;
    private IntroManager introManager;

    void Start()
    {
        cam = GameObject.Find("MainVirtualCamera");
        introManager = GameObject.Find("IntroPlayer").GetComponent<IntroManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(introManager.hasGameStarted) transform.position = new Vector3(transform.position.x, cam.transform.position.y , transform.position.z);

        //if (introManager.hasGameStarted) Debug.Log("KEK");
    }
}
