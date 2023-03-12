using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed,jumpValue;

    EziciKutuController eziciKutuController;
    [SerializeField]
    float geriTepmeGucu;

    [SerializeField]
    float sekmeGucu;

    Animator playerAnimator;
    Rigidbody2D rb;
    bool yerdemi = true;
    bool secondMove = false;
    bool yonSagmi;
    

    public float geriTepmeSuresi;
    float geriTepmeSayaci;



    public bool hareketEtsinmi;
    private void Awake()
    {
        eziciKutuController = Object.FindObjectOfType<EziciKutuController>();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }


    private void Start()
    {
        hareketEtsinmi = true;
    }

    void Update()
    {
        if (hareketEtsinmi)
        {
            if (geriTepmeSayaci <= 0f)
            {
                PlayerMove();
                PlayerJump();
                YonDegistir();
                if (eziciKutuController.frogDeadOfPlayer == true)
                {
                    SekmeFNC();
                    eziciKutuController.frogDeadOfPlayer = false;
                }


            }
            else
            {
                geriTepmeSayaci -= Time.deltaTime;
                if (yonSagmi == true)
                {
                    rb.velocity = new Vector2(-geriTepmeGucu, rb.velocity.y);

                }
                else
                {
                    rb.velocity = new Vector2(geriTepmeGucu, rb.velocity.y);
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        playerAnimator.SetFloat("y-Ekseni", rb.velocity.y);
        playerAnimator.SetBool("yerdemi", yerdemi);
        playerAnimator.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float MoveValue = h * moveSpeed;

        rb.velocity = new Vector2(MoveValue, rb.velocity.y);

        playerAnimator.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
            if (yerdemi == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpValue);
                
                secondMove = true;
                yerdemi = false;
                SoundController.instance.sesEfektiCikarFNC(7);
            }
            else
            {
                if (secondMove == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpValue);
                    secondMove = false;
                    yerdemi = false;
                    SoundController.instance.sesEfektiCikarFNC(7);
                }
                
            }
            
            
        }
        



        
        
        

    }

    private void OnCollisionEnter2D(Collision2D target)
    {
       
        if (target.gameObject.tag == "zemin")
        {
            yerdemi = true;
            
            
        }
    }
    void YonDegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if (rb.velocity.x <0)
        {
            yonSagmi = false;
            geciciScale.x = -6f;
        }
        else if (rb.velocity.x > 0)
        {
            yonSagmi = true;
            geciciScale.x = 6f;

        }
        transform.localScale = geciciScale;
    }

    public void GeriTepmeFNC()
    {
      geriTepmeSayaci = geriTepmeSuresi;

        playerAnimator.SetTrigger("hasar");
    }

    

    public void SekmeFNC()
    {
        
            rb.velocity = new Vector2(rb.velocity.x, sekmeGucu);
            
        
    }
}
