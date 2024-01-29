using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton instance
    private static SoundManager instance;

    // Serialized fields
    [SerializeField] GameObject menuTheme, levelTheme, idle, boost, rebuild, coin, stone, inici;


    public float volumeLevel;

    private void Start()
    {
        volumeLevel = 0.3f;
    }

    // Public property to access the singleton instance
    public static SoundManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Ensure there's only one instance of SoundManager
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ChangeToGameTheme()
    {
        StartCoroutine(Change());
    }


    public void AdmireParalax()
    {
        levelTheme.GetComponent<AudioSource>().volume += volumeLevel + 0.2f;
        idle.GetComponent<AudioSource>().volume += volumeLevel - 0.2f;
    }
    public void AdmireParalaxN()
    {
        levelTheme.GetComponent<AudioSource>().volume += volumeLevel - 0.2f;
        idle.GetComponent<AudioSource>().volume += volumeLevel + 0.2f;
    }

    private IEnumerator Change()
    {
       // Debug.Log("KEk");
        for (int i = 0; i < 10; i++)
        {
            //Debug.Log("GOLA");
            menuTheme.GetComponent<AudioSource>().volume -= 0.03f;
            levelTheme.GetComponent<AudioSource>().volume += 0.03f;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void OpenPause()
    {
        levelTheme.GetComponent<AudioSource>().volume = 0.0f;
        idle.GetComponent<AudioSource>().volume = 0.0f;
       // Debug.Log("SONIUDO");
    }
    public void ClosePause()
    {
        levelTheme.GetComponent<AudioSource>().volume = volumeLevel;
        idle.GetComponent<AudioSource>().volume = volumeLevel;
        
    }


    public void StartIdle()
    {
        idle.SetActive(true);
    }
    public void IniciSound()
    {
        inici.GetComponent<AudioSource>().Play();
    }
    public void CoinSound()
    {
        //coin.GetComponent<AudioSource>().Play();
        GameObject coinP;

        coinP = Instantiate(coin, transform.position, Quaternion.identity);
        Destroy(coinP, 1f);
    }
    public void StoneSound()
    {
        stone.GetComponent<AudioSource>().Play();
    }
    public void StopIdle()
    {
        idle.SetActive(false);
    }

    public void Boost()
    {
        boost.GetComponent<AudioSource>().Play();
    }
    public void Rebuild()
    {
        rebuild.GetComponent<AudioSource>().Play();
    }
}