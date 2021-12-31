using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D theRB;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] Transform groundPoint;

    public LayerMask whatIsGround;

    private bool _isOnGround;

    public Animator anim;


    private void Start() 
    {
        
    }

    private void Update() 
    {
        Movement();

        anim.SetBool("isOnGround", _isOnGround);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));


    }

    public void Movement()
    {
        // move sideways
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        //handle direction change
        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


        //checking if on the ground
        _isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        //jumping
        if(Input.GetButtonDown("Jump") && _isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }
}
