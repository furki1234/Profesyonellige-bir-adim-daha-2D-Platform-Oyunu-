using System.Collections;
using System.Collections.Generic;
using UnityEditor.iOS;
using UnityEngine;

public class EziciKutuController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    GameObject DeadEffect;

    [SerializeField]
    GameObject Mucevher, Kiraz;

    public float MucevherSansi, KirazSansi;
    float MucevherCikmaAraligi, KirazCikmaAraligi;
    public GameObject frog;
    public bool frogDeadOfPlayer;
    PlayerHealthController playerHealthController;
    [SerializeField]
    Transform Frog;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kurbaga"))
        {
            MucevherCikmaAraligi = Random.Range(1, 100);
            KirazCikmaAraligi = Random.Range(1, 100);

            SoundController.instance.sesEfektiCikarFNC(10);


            if (MucevherCikmaAraligi <= MucevherSansi)
            {
                Instantiate(Mucevher, other.transform.position, other.transform.rotation);

            }
            if (KirazCikmaAraligi <= KirazSansi)
            {
                Instantiate(Kiraz, other.transform.position, other.transform.rotation);

            }
            Instantiate(DeadEffect, transform.position, transform.rotation);
            other.transform.parent.gameObject.SetActive(false);
            rb.velocity = new Vector2(0, rb.velocity.y);
            frogDeadOfPlayer = true;
            


            
            if (playerHealthController.Health != playerHealthController.saveHealth)
            {
                playerHealthController.Health = playerHealthController.saveHealth;
            }
        }
    }
}
