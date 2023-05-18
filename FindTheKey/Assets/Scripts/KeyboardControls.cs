using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour
{
    //config params
    [SerializeField] private float _speed = 20;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _groundCheckRadius = .5f;

    [SerializeField] private Transform _grouchCheck;
    [SerializeField] private LayerMask _whatIsGround;


    //cached component refernces
    private Rigidbody2D _myRigidbody;
    private BoxCollider2D _myBoxCollider;

    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
        _myBoxCollider = GetComponent<BoxCollider2D>();
       
    }

    
    private void FixedUpdate()
    {

        MovePlayer();
        if (Input.GetButton("Jump"))
        {
            if (isGrounded())
            {
                AudioManager.Instance.PlayJumpSound();
                _myRigidbody.velocity += new Vector2(0, _jumpForce);
            }
        }
    }
    private void MovePlayer()
    {
        float xInput = Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;

        _myRigidbody.velocity = new Vector2(xInput, _myRigidbody.velocity.y);
    }

    //public void Jump()
    //{
    //    Vector2 jumpVelocityToAdd = new Vector2(0f, _jumpForce);
    //    _myRigidbody.velocity += jumpVelocityToAdd;
    //}


    private bool isGrounded()
    {

        return Physics2D.OverlapCircle(_grouchCheck.position, _groundCheckRadius, _whatIsGround);
    }

}
