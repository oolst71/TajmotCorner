using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    CapsuleCollider2D touchingColl;
    public float groundDistance = 0.05f;

    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    private bool _isGround = true;
    public bool IsGround { get {
            return _isGround;
        }
        private set {
            _isGround = value;
            animator.SetBool("isGrounded", value);
        } }

    private void Awake()
    {
        touchingColl = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        IsGround = touchingColl.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
