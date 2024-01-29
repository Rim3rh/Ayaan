using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class PlayerDeathTemp : MonoBehaviour
{
    [SerializeField] GameObject playerAnim, player, hud;
    public GameObject deathPanel;

    public bool dead;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if(collision.CompareTag("dead")) StartCoroutine(EndGameC());
        //Muerte por caida
        if (collision.gameObject.layer == 8)
        {
            StartCoroutine(EndGameC());

        }
        if (collision.gameObject.layer == 11)
        {
            StartCoroutine(EndGameC2());

        }

    }
    
    public IEnumerator EndGameC()
    {
        
        playerAnim.GetComponent<Animator>().SetBool("Dead", true);
        dead = true;
        player.GetComponent<PlayerJump>().canRotate = false;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        player.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        playerAnim.GetComponent<Animator>().SetBool("Fall", true);
        //yield return new WaitForSeconds(2f);
        player.GetComponent<CameraFOV>().onEntry = true;

        for (int i = 0; i < 60; i++)
        {
            player.GetComponent<Rigidbody2D>().drag = 8f;
          //  Debug.Log(player.GetComponent<PlayerMovement>().currentMaxVel);
            if (player.GetComponent<PlayerMovement>().currentMaxVel < 0)
            {

            }
            else
            {
                player.GetComponent<PlayerMovement>().currentMaxVel = player.GetComponent<PlayerMovement>().currentMaxVel - 1f;
                yield return new WaitForSeconds(0.04f);
            }
           
            Debug.Log("DEJO DE ENTRAR");
        }
        player.GetComponent<PlayerMovement>().currentMaxVel = 0f;

        player.GetComponent<Rigidbody2D>().drag = 100f;
        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        deathPanel.SetActive(true);
        hud.SetActive(false);
        deathPanel.GetComponent<DethScene>().SetValues();
    }



    public IEnumerator EndGameC2()
    {

        playerAnim.GetComponent<Animator>().SetBool("Dead", true);
        player.GetComponent<PlayerJump>().canRotate = false;
        //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        player.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
        playerAnim.GetComponent<Animator>().SetBool("Fall", true);
        //yield return new WaitForSeconds(2f);
        player.GetComponent<CameraFOV>().onEntry = true;

        for (int i = 0; i < 60; i++)
        {
            Debug.Log(player.GetComponent<PlayerMovement>().currentMaxVel);
            if (player.GetComponent<PlayerMovement>().currentMaxVel < 0)
            {

            }
            else
            {
                player.GetComponent<PlayerMovement>().currentMaxVel = player.GetComponent<PlayerMovement>().currentMaxVel - 1f;
                yield return new WaitForSeconds(0.04f);
            }

            Debug.Log("DEJO DE ENTRAR");
        }
        player.GetComponent<PlayerMovement>().currentMaxVel = 0f;

        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        deathPanel.SetActive(true);
        hud.SetActive(false);
        deathPanel.GetComponent<DethScene>().SetValues();
    }


    
}
