using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ParadaxLogic : MonoBehaviour
{
    
    [SerializeField] private GameObject paradax;
    [SerializeField] private GameObject cube;
    void Start()
    {
        //mainCamera = GameObject.Find("--MAINCAM--");
    }

    private void LateUpdate()
    {
        Vector3 bottomLeftCorner = cube.transform.position - cube.transform.localScale / 2f;

        paradax.transform.position = new Vector3(bottomLeftCorner.x, bottomLeftCorner.y, paradax.transform.position.z);
    }




}
