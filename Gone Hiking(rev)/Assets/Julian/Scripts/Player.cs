using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // player traits
    public float speed = 5f;
    public float jumpHeight = 15f;

    // detecting ground below player to jump
    private LayerMask groundLayer;
    private float groundDetectionRange = 0.5f;

    // if player is touching the ground
    private bool grounded = false;

    // other components
    private Rigidbody2D rb;

    void Start() {
        // access rigid body component
        rb = GetComponent<Rigidbody2D>();

        // access layer of ground. This will be detected by the player to jump.
        groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        // get horizontal input and move player
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // check if currently touching the ground
        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionRange, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.red, groundDetectionRange);

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded) {

                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
    }
}
