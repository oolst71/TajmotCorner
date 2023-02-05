using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ProtoPlayerController : MonoBehaviour
{
    public float walkSpeed = 10f;

    Vector2 moveInput;

    private bool _isMoving = false;

    // Dash shit
    int dashesLeft = 2;
    float dashtimer = 0;
    Vector2 dashDirection;
    float dashSpeed = 35f;
    public bool dashing = false;
    private float coyoteTimer = 0f;
    public GameObject respawnPoint;

    SpriteRenderer render;

    [SerializeField] private TrailRenderer tr;

    TouchingDirections touchingDirections;

    public bool IsMoving { get
        {
            return _isMoving;
        }
            private set 
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        } 
    }

    public bool _IsFacingRight = true;

    public bool IsFacingRight { 
        get { return _IsFacingRight; } 
        private set {
            if (_IsFacingRight != value) 
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _IsFacingRight = value;

            } }

    Rigidbody2D rb;
    Animator animator;
    private float jumpImpulse = 22f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        render = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Dash shit
        if (dashtimer > 0)
        {
            dashtimer -= (1 * Time.deltaTime);
            rb.velocity = new Vector2(dashDirection.x * dashSpeed, dashDirection.y * dashSpeed);
            rb.gravityScale = 0;
        }

        //Normal Move
        if (dashtimer <= 0)
        {
            rb.gravityScale = 5;
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);
            if (dashing)
            {
                dashing = false;
                rb.velocity = Vector2.zero;
                SetFacingDirection(moveInput);
                tr.emitting = false;
            }
        }

        if (touchingDirections.IsGround)
        {
            dashesLeft = 2;
            coyoteTimer = 0;
        }
        else
        {
            coyoteTimer += Time.deltaTime;
        }
       

        animator.SetFloat("yVelocity", rb.velocity.y);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (!dashing)
        {
        if (moveInput.x > 0 && !IsFacingRight)
        {

            IsFacingRight = true;

        } else if (moveInput.x < 0 && IsFacingRight) 
        {

            IsFacingRight = false;
        }
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && coyoteTimer < 0.12f)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }


    //When Dash button is pressed
    public void OnDash(InputAction.CallbackContext context)
    {
        
        if (dashesLeft > 0 && dashtimer <= 0 && IsMoving && context.started)
        {

            animator.SetTrigger("dash");

            dashing = true;

            dashDirection = moveInput;

            dashtimer = 0.25f;

            dashesLeft--;

            tr.emitting = true;

            
        }
    
    }

    public void OnDeath()
    {
        rb.velocity = Vector2.zero;
        tr.emitting = false;
        transform.position = new Vector3(respawnPoint.transform.position.x, respawnPoint.transform.position.y, transform.position.z);
    }

    public void LevelEnd(int nextIndex)
    {
        SceneManager.LoadScene(nextIndex);
    }
}
