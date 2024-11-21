using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool X;
    public bool Y;
    public bool Static;
    public Vector3 startPos;

    private void Awake() {
        transform.position = startPos;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Y){
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        else if (X){
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else if (Static){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else{
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
