using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{

    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("--Player--");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Speed+1")) player.GetComponent<PlayerMovement>().currentMaxVel++;
        if (collision.CompareTag("Speed-1")) player.GetComponent<PlayerMovement>().currentMaxVel--;
    }


}
