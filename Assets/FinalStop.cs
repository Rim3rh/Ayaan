using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStop : MonoBehaviour
{
    [SerializeField] GameObject playerFin;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playera, dead;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playera.GetComponent<Rigidbody2D>().drag = 15f;
            Debug.Log("GASDNOIUPAO=");
            player.SetActive(false);
            playerFin.SetActive(true);
            dead.GetComponent<DethScene>().SetValues();

        }

    }




}
