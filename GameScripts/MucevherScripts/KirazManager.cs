using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirazManager : MonoBehaviour
{
    LevelManager levelManager;
    UIController uiController;
    PlayerHealthController playerHealthController;

    // Start is called before the first frame update
    bool toplandimi = false;

    
    [SerializeField]
    GameObject CollectEffect;
    
    
    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uiController = Object.FindObjectOfType<UIController>();
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !toplandimi && playerHealthController.Health!=playerHealthController.maxHealth)
        {
           
            playerHealthController.CaniArttirFNC();
            Destroy(gameObject);
            Instantiate(CollectEffect, transform.position, transform.rotation);
            toplandimi=true;
            SoundController.instance.sesEfektiCikarFNC(6);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
