using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlController : MonoBehaviour
{

    [Header("Transforms")]

    public Transform cam;
    public Transform player;

    [Header("Coordinates")]

    public Vector3 camCoords;
    public Vector3 playerCoords;

    [Header("CamControls")]
    public bool FollowX;
    public bool FollowY;
    public bool Static;

    [Header("Objects")]
    public GameObject prevParticles;
    public GameObject presParticles;


    private PlayerMovementSide move_script;
    private CameraController cam_script;



    // Start is called before the first frame update
    void Start()
    {
       move_script = player.GetComponent<PlayerMovementSide>();
       cam_script = cam.GetComponent<CameraController>(); 
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        if(other.CompareTag("Player")){
            move_script.canMove = false;
            if (prevParticles != null){
                prevParticles.SetActive(false);
            }
            cam.transform.position = camCoords;
            player.transform.position = playerCoords;
            if (FollowX){
                cam_script.X = true;
                cam_script.Y = false;
                cam_script.Static = false;
            }
            else if (FollowY){
                cam_script.X = false;
                cam_script.Y = true;
                cam_script.Static = false;
            }
            else if (Static){
                cam_script.X = false;
                cam_script.Y = false;
                cam_script.Static = true;
            }
            else{
                cam_script.X = false;
                cam_script.Y = false;
                cam_script.Static = false;
            }

            if (presParticles != null){
                presParticles.SetActive(true);
            }
            move_script.canMove = true;
        }    
    }
}
