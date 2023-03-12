using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && !toplandimi)
        {
            
            levelManager.ToplananMucevherSayisi++;
            Instantiate(CollectEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            uiController.MucehverSayisiniGuncelleFNC();
            toplandimi = true;


            SoundController.instance.sesEfektiCikarFNC(4);
        }
    }
}
