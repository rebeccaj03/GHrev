using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb2d;
    public Vector2 moveInput;
    public SpriteRenderer spriteRenderer;
    private AnimTD anim;

    private void Start() {
        anim = GetComponent<AnimTD>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        anim.SetHorizontalMovement(x, y);
        if (x < 0){
            anim.Flip(-1);
        }
        if (x > 0){
            anim.Flip(1);
        }

    }
}
