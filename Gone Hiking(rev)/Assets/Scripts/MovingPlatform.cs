using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [Header("Transform")]
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public GameObject player;

    [Header("Stats")]
    public float moveSpeed = 1.5f;
    public float returnSpeed = 0.8f;
    
    public int direction = 1;

    [Header("Bools")]

    public bool Collided = false;
    public bool Moveable = true;

    private PlayerMovementSide move;


    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<PlayerMovementSide>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();
        float distance = (target - (Vector2)platform.position).magnitude;

        if (platform.position == endPoint.position){
            Moveable = false;
            Collided = false;
        }
        if (platform.position == startPoint.position){
            Moveable = true;
        }
        if (Collided && Moveable){
            platform.position = Vector2.MoveTowards(platform.position, target, moveSpeed * Time.deltaTime);
            distance = (target - (Vector2)platform.position).magnitude;
            if (distance <= 0.1f){
                direction = -1;
            }
        }
        else {
            target = currentMovementTarget();
            platform.position = Vector2.MoveTowards(platform.position, target, returnSpeed * Time.deltaTime);
            distance = (target - (Vector2)platform.position).magnitude;
             if (distance <= 0.1f){
                direction = 1;
            }
        }
    }

    public Vector2 currentMovementTarget(){
        if (direction == 1){
            return startPoint.position;
        }
        else{
            return endPoint.position;
        }
    }

    private void OnDrawGizmos() {
        if(platform != null && startPoint != null && endPoint != null){
            Gizmos.DrawLine(platform.transform.position, startPoint.transform.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.transform.position);
        }
    }


    //Not working everytime because of this
    private void OnCollisionEnter2D(Collision2D other) {
        if(Moveable){
        Collided = true;
        }
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other){
        
        other.transform.SetParent(null);
    }
}
