using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float Health, maxHealth;
    UIController uiController;
    public GameObject DeadEffect;
   
    public float hasarSuresi;
    float hasarSayaci;

    public float geriTepmeSuresi;
    float geriTepmeSayaci;
    SpriteRenderer spriteRe;

    PlayerController playerController;
    LevelManager levelManager;

    public float saveHealth;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        uiController = Object.FindObjectOfType<UIController>();
        spriteRe = GetComponent<SpriteRenderer>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }
    private void Start()
    {
        hasarSayaci = hasarSuresi;
        Health = maxHealth;
        saveHealth = maxHealth;
    }

    private void Update()
    {
        hasarSayaci -= Time.deltaTime;
        

        if (hasarSayaci <= 0f)
        {
            spriteRe.color = new Color(255f, 255f, 255f, 255f);
        }

        if (Health != saveHealth)
        {
            Health = saveHealth;
        }
    }
    public void OttanHasarAlFNC()
    {

       
        if (hasarSayaci <= 0)
        {
            
            Health--;
            saveHealth = Health;
            if (Health <= 0)
            {
                Health = 0;
                gameObject.SetActive(false);
                Instantiate(DeadEffect, transform.position, transform.rotation);
                SoundController.instance.sesEfektiCikarFNC(8);
                levelManager.GameOver();
            }
            else
            {
                spriteRe.color = new Color(spriteRe.color.r, 0.6f, 0.6f, spriteRe.color.a);
               
                hasarSayaci = hasarSuresi;
                playerController.GeriTepmeFNC();
                SoundController.instance.sesEfektiCikarFNC(9);
            }
            uiController.UpdateHealthFNC();
            
        }
        
    }
    public void KurbagadanHasarAlFNC()
    {
        if (hasarSayaci <= 0)
        {

            Health-= 2;
            saveHealth = Health;
            if (Health <= 0)
            {
                Health = 0;
                gameObject.SetActive(false);
                Instantiate(DeadEffect, transform.position, transform.rotation);
                SoundController.instance.sesEfektiCikarFNC(8);
                levelManager.GameOver();
            }
            else
            {
                spriteRe.color = new Color(spriteRe.color.r, 0.6f, 0.6f, spriteRe.color.a);

                hasarSayaci = hasarSuresi;
                playerController.GeriTepmeFNC();
                SoundController.instance.sesEfektiCikarFNC(9);
            }
            
            uiController.UpdateHealthFNC();

        }
    }
    public void MermidenHasarAlFNC()
    {
        if (hasarSayaci <= 0)
        {

            Health -= 2;
            saveHealth = Health;
            if (Health <= 0)
            {
                Health = 0;
                gameObject.SetActive(false);
                Instantiate(DeadEffect, transform.position, transform.rotation);
                SoundController.instance.sesEfektiCikarFNC(8);
                levelManager.GameOver();
            }
            else
            {
                spriteRe.color = new Color(spriteRe.color.r, 0.6f, 0.6f, spriteRe.color.a);

                hasarSayaci = hasarSuresi;
                playerController.GeriTepmeFNC();
                SoundController.instance.sesEfektiCikarFNC(9);
            }

            uiController.UpdateHealthFNC();

        }
    }

    public void MayindanHasarAlFNC()
    {
        if (hasarSayaci <= 0)
        {

            Health -= 3;
            saveHealth = Health;
            if (Health <= 0)
            {
                Health = 0;
                gameObject.SetActive(false);
                Instantiate(DeadEffect, transform.position, transform.rotation);
                SoundController.instance.sesEfektiCikarFNC(8);
                levelManager.GameOver();
            }
            else
            {
                
                spriteRe.color = new Color(spriteRe.color.r, 0.6f, 0.6f, spriteRe.color.a);

                hasarSayaci = hasarSuresi;
                playerController.GeriTepmeFNC();
                SoundController.instance.sesEfektiCikarFNC(9);
            }

            uiController.UpdateHealthFNC();

        }
    }
        
    

    public void CaniArttirFNC()
    {
        Health++;
        if (Health >= maxHealth)
        {

            Health = maxHealth;
        }
       
        uiController.UpdateHealthFNC();
        saveHealth = Health;
    }
}
