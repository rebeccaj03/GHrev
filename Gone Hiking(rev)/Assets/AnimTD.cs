using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTD : MonoBehaviour
{
    
    private Animator anim;
    public SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHorizontalMovement(float x,float y)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
    }

    public void Flip(int side)
    {

        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
