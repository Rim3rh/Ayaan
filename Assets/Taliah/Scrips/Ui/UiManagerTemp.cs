using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UiManagerTemp : MonoBehaviour
{

    [SerializeField] private GameObject playerHud;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject jumpHud;
    [SerializeField] private GameObject WinHud;
    private PlayerInput _playerInputActions;

    [SerializeField] Slider _slider;

    private void Start()
    {
        _playerInputActions = player.GetComponent<PlayerInput>();
    }
    public void RestartScene()
    {
        player.GetComponent<PlayerInput>().enabled = false;

        Time.timeScale = 1f;
        StopAllCoroutines();
        _playerInputActions.actions["Boost"].Disable();
        _playerInputActions.actions["Jump"].Disable();
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        playerHud.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SoundManager.Instance.ClosePause();

    }
    public void OpenPauseMenu()
    {
        playerHud.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        SoundManager.Instance.OpenPause();

    }

    public void OpenOptionsMenu()
    {
        
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);

        
    }
    public void CloseOptionsMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        
    }

    public void JumpHud(bool jumpHudB)
    {
        print(jumpHudB);
        if(jumpHudB)jumpHud.GetComponent<Image>().enabled = true;
        else jumpHud.GetComponent<Image>().enabled = false;

    }

    public void UpdateSlider()
    {
        SoundManager.Instance.volumeLevel = _slider.value;
    }

    public void YouWin()
    {
        WinHud.SetActive(true);
    }


}
