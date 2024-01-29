using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnterZoneTemp : MonoBehaviour
{
    public event Action EnterZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) EnterZone?.Invoke();
    }
}
