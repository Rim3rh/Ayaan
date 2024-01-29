using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    private GameObject animatedPlayer, animatedCamera, player, parallax;
    [SerializeField] GameObject hud, caldero, titulo, storyText;
    public bool canGameStart;
    public bool hasGameStarted;
    void Start()
    {
        player = GameObject.Find("--Player--");
        animatedCamera = GameObject.Find("IntroCam");
        animatedPlayer = GameObject.Find("IntroPlayer");
        parallax = GameObject.Find("--Paralax--");


    }


    public void PlayPlayerIntro()
    {
        animatedPlayer.GetComponent<Animator>().Play("PlayerEntryAnim");
        
    }

    public void StartGame()
    {
        
        player.GetComponent<Rigidbody2D>().gravityScale = 20;
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500, ForceMode2D.Impulse);
        player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 500, ForceMode2D.Impulse);
        player.GetComponent<PlayerMovement>().StartCoroutine("Entry");
        player.transform.Find("Animacion").gameObject.SetActive(true);
        player.GetComponent<CameraFOV>().StartCoroutine("Entry");
        parallax.GetComponent<Animator>().Play("parallaxGoToPos");

        Invoke(nameof(hudActive), 1.5f);

        hasGameStarted = true;
        
        //SOUND
        
        SoundManager.Instance.StartIdle();
       
        
    }


    private void hudActive()
    {
        hud.SetActive(true);
    }

    public void PlayCalderoAnim()
    {
        caldero.GetComponent<Animation>().enabled = true;
    }

    public void CanStart()
    {
        animatedPlayer.GetComponent<IntroManager>().canGameStart = true;
        //(storyText.SetActive(true);
    }

    public void SetAnimToFAlse()
    {
        parallax.GetComponent<Animator>().enabled = false;
    }
    public void SwitchCam()
    {
        animatedCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
    }
    public void PlayCameraZoom()
    {

        if (canGameStart)
        {
            SoundManager.Instance.ChangeToGameTheme();
            storyText.GetComponent<Animator>().Play("StoryTextFadeOut");
            titulo.GetComponent<Animation>().Play();
            animatedCamera.GetComponent<Animator>().Play("CamZoom");
            //transform.GetComponentInParent<GameObject>().SetActive(false);
            GameObject.Find("IntroCanvas").SetActive(false);
        }

        
    }

    public void Caldero()
    {
        //caldero.GetComponent<Animation>().enabled = true;
        caldero.GetComponent<Animation>().Play();
    }
    public void PlaySound()
    {
        SoundManager.Instance.IniciSound();
    }
}
