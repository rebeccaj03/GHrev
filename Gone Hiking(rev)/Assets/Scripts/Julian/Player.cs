using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // normalize movement to prevent faster diagonal movement
        movement.normalized;
        
        // advance position
        gameObject.transform.position = new Vector2(position.x + movement.x, position.y + movement.y);
    }
}
