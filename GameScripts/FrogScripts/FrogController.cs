using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Transform SolHedef, SagHedef;
    public SpriteRenderer spriteRe;

    Animator frogAnimator;

    float moveTime, waitTime;
    float moveCounter, waitCounter;

    Rigidbody2D rb;

    bool sagTarafta;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        frogAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        moveTime = Random.Range(3, 10);
        sagTarafta = true;
        moveCounter = moveTime;
        SolHedef.parent = null;
        SagHedef.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        FrogMoveFNC(); 

        
    }

    void FrogMoveFNC()
    {
        
        if (moveCounter > 0)
        {
            
            moveCounter -= Time.deltaTime;
            if (sagTarafta)
            {
                spriteRe.flipX = true;
                
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                if (transform.position.x > SagHedef.position.x)
                {
                    sagTarafta = false;
                }
            }
            else
            {
                spriteRe.flipX = false;
                
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                if (transform.position.x < SolHedef.position.x)
                {
                    sagTarafta = true;
                }
            }
            if(moveCounter <= 0)
            {
                waitTime = Random.Range(1, 6);
                waitCounter = waitTime;
            }
            frogAnimator.SetBool("moving", true);
            
        }
        else if (waitCounter > 0)
        {
            
            waitCounter -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (waitCounter <= 0)
            {
                moveTime = Random.Range(3, 10);
                moveCounter = moveTime;
            }
            frogAnimator.SetBool("moving", false);
        }
        
    }
}
