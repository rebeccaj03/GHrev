using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform Player;
    
    private void Awake() {
       Player.transform.position = transform.position;
    }
}
