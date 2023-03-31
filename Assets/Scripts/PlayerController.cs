using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{//Here we define the variables that we are going to use and that we are going to edit in unity to gave us the velocity the jump force, etc.
    public static PlayerController instance;
    [Header("Movimiento")]
    public float moveSpeed;

    [Header("Componentes")]
    public Rigidbody2D theRB;
    
    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;
    public float bounceForce;

    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;

    [Header("Ground Check")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    public float knockBackLenght, knockBackForce;
    private float knockBackCounter;

    public bool stopInput;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

   //Player movement with this code we can make the character move, like the jumps and the inputs that we are going to use to move
    void Update()
{
        if(!stopInput)
        {
            if(knockBackCounter <= 0){
       theRB.velocity = new Vector2(moveSpeed*Input.GetAxisRaw("Horizontal"),theRB.velocity.y);

       isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);


       if(isGrounded){
       canDoubleJump = true; 
       }
       if(Input.GetButtonUp("Jump"))
       {
        if(isGrounded)
        {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }else
        {
            if(canDoubleJump)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
       }
       if(theRB.velocity.x < 0 )
       {
        theSR.flipX = true;
       } else if(theRB.velocity.x > 0)
       {
        theSR.flipX = false;
       }
       }
       else{
        knockBackCounter -= Time.deltaTime;
       }
        }
       anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
       anim.SetBool("isGrounded",isGrounded);
    
}

    public void knockBack()
    {
    knockBackCounter=knockBackLenght;
    theRB.velocity = new Vector2(0f, knockBackForce);
    }
    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }
        
}

