using System.Collections;
using UnityEngine;
 
public class FallingPlat : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float destroyDelay = 2f;
 
    private bool falling = false;
 
    [SerializeField] private Rigidbody2D rb;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Avoid calling the coroutine multiple times if it's already been called (falling)
        if (falling)
            return; 
 
        // If the player landed on the platform, start falling
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(transform);
            StartCoroutine(StartFall());
        }
    }
 
    private IEnumerator StartFall()
    {
        falling = true; 
 
        // Wait for a few seconds before dropping
        yield return new WaitForSeconds(fallDelay);
 
        // Enable rigidbody and destroy after a few seconds
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionExit2D(Collision2D other){
        if (other.transform.tag == "Player"){
        other.transform.SetParent(null);
        }
    }
}