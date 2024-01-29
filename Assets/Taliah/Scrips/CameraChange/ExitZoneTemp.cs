using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitZoneTemp : MonoBehaviour
{
    public event Action ExitZone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ExitZone?.Invoke();
    }
}
