using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private Vector2 deathKick = new Vector2(5f, 5f);

    // State
    private bool isAlive = true;
   
    // Cached component references
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private BoxCollider2D myFeetCollider;
    private CapsuleCollider2D myBodyCollider;

    float gravityScaleAtStart;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }
    
    void Update()
    {
        if (!isAlive) { return; }
        
        run();
        jump();
        climbLadder();
        die();
        flipSprite();
        
    }

    private void run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // Value is betweeen -1 and +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerIsRunning = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerIsRunning);
    }

    private void jump()
    {
        bool playerIsTouchingGround = myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (Input.GetButtonDown("Jump") && playerIsTouchingGround)
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }

    private void climbLadder()
    {
        bool playerIsTouchingLadder = myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));

        if (playerIsTouchingLadder)
        {
            float controlThrow = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
            myRigidbody.velocity = climbVelocity;
            myRigidbody.gravityScale = 0f;

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);

        }
        else
        {
            myAnimator.SetBool("isClimbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
        }
        
    }

    private void die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            myAnimator.SetTrigger("Die");
            myRigidbody.velocity = deathKick;
            isAlive = false;
            FindObjectOfType<GameSession>().processPlayerDeath();
        }
    }

    private void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
