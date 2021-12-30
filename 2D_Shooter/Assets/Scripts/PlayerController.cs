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


    private void Start() 
    {
        
    }

    private void Update() 
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

        _isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

        if(Input.GetButtonDown("Jump") && _isOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }
}
