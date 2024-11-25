using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntro : MonoBehaviour
{
    // traits of player
    public float moveSpeed = 5f;    // speed of player

    // access rigid body and movement
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start() {
        // access rigid body component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // get player input
        movement.x = Input.GetAxisRaw("Horizontal");    // left and right movement
        movement.y = Input.GetAxisRaw("Vertical");      // up and down movement
    }

    // update for physics objects
    void FixedUpdate()
    {
        // apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
