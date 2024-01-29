using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReferences : MonoBehaviour
{
    [SerializeField] GameObject canvasfin;

    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject hud;

    public void EndGame()
    {
        Time.timeScale = 0;
    }

    public void Finished()
    {
        SoundManager.Instance.OpenPause();
        canvasfin.SetActive(true);
        hud.SetActive(false);

    }

    public void cosas()
    {
        virtualCamera.Priority = 0;
    }
}
