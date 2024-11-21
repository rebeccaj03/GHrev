using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsCheck : MonoBehaviour
{
    [Header("Nums")]
    public float DeathWaitTime;

    [Header("Objects")]
    [SerializeField]private Animator anim;
    public GameObject player;
    public Vector2 Checkpoint;

    private PlayerMovementSide bool_script;
    private bool dead;

    void Start() {
        bool_script = player.GetComponent<PlayerMovementSide>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player"){
            dead = true;
            bool_script.canMove = false;
            StartCoroutine(Death());
        }
    }

    public IEnumerator Death(){
        anim.Play("Death", 0,0.0f);
        //yield return new WaitForSeconds(0.2f);
        //source.Play(); audio scource things
        yield return new WaitForSeconds(DeathWaitTime);
        player.transform.position = Checkpoint;
        anim.Play("Idle", 0,0.0f);
        bool_script.canMove = true;
        dead = false;
    }
}
