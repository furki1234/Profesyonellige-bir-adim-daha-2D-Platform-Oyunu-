using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurbagaHasarController : MonoBehaviour
{
    PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            playerHealthController.KurbagadanHasarAlFNC();
        }
    }
}
