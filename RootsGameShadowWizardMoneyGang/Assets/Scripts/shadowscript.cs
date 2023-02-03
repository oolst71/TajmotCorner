using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowscript : MonoBehaviour
{
    // Start is called before the first frame update

    //Penis music

    //Don't worry, it was 50% off

    public float moveSpeed = 10;
    public Vector2 inputDirection;

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.


        inputDirection.y = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        inputDirection.Normalize();

        rb.velocity = new Vector2(inputDirection.x, inputDirection.y).normalized * moveSpeed;

        //transform.Translate(new Vector3(inputDirection.x, inputDirection.y, 0) * moveSpeed * Time.deltaTime);
        ////Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
    }
}
