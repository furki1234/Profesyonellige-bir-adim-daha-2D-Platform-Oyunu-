using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayinController : MonoBehaviour
{
    public GameObject boomEffect;

    PlayerHealthController playerHealthController;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PatlamaFNC();

            playerHealthController.MayindanHasarAlFNC();
        }
    }


    public void PatlamaFNC()
    {
        Destroy(this.gameObject);

        Instantiate(boomEffect, transform.position, transform.rotation);
    }
}
