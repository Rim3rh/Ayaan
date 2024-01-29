using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLogic : MonoBehaviour
{
    [SerializeField] GameObject stone, stone2, stone3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DethScene.gemCounter++;
            SoundManager.Instance.StoneSound();
            stone.SetActive(true);
            stone2.SetActive(true);
            stone3.SetActive(true);
            Destroy(gameObject);
        }
    }
}
