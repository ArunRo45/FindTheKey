using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class TouchControls : MonoBehaviour
{

    //Configuration Parameters
    [Header("Movement")]
    [SerializeField] private  float speed = 300f;
    [SerializeField] private  float jumpForce = 2500f;


    [Header("Jump Checks")]
    [SerializeField] private float _groundCheckRadius = .5f;
    [SerializeField] private Transform _grouchCheck;
    [SerializeField] private LayerMask _whatIsGround;
    
    private float horizontalMove;
  
    private bool isPlayerCanJump;
    private bool isMovingLeft;
    private bool isMovingRight;


    private Rigidbody2D myrigidbody2D;

    private void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        isMovingLeft = false;
        isMovingRight = false;
        
    }


    private void Update()
    {
        //moving
        MoveByTouch();
    }
 
    private void FixedUpdate()
    {

        
        myrigidbody2D.velocity = new Vector2(horizontalMove * Time.fixedDeltaTime, myrigidbody2D.velocity.y);


        //Jumping
        if (isGrounded())
        {
            if (isPlayerCanJump)
            {
                myrigidbody2D.velocity += new Vector2(0f, jumpForce);
                AudioManager.Instance.PlayJumpSound();
            }
        }
        else
        {
            isPlayerCanJump = false;
        }
    }



    public void OnLeftDown()
    {
        isMovingLeft = true;
        //Debug.Log(isMovingLeft);
    }

    public void OnLeftUp()
    {
        isMovingLeft = false;
        //Debug.Log(isMovingLeft);
    }

    public void OnRightDown()
    {
        isMovingRight = true;
    }

    public void OnRightUp()
    {
        isMovingRight = false;
    }

    void MoveByTouch()
    {
        //Moving
        if (isMovingLeft)
        {
            horizontalMove = -speed;
          
        }
        else if (isMovingRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }

    }

   
    public void OnJump()
    {
        isPlayerCanJump = true;
 
    }


    private bool isGrounded()
    {

        return Physics2D.OverlapCircle(_grouchCheck.position, _groundCheckRadius, _whatIsGround);
    }

}
