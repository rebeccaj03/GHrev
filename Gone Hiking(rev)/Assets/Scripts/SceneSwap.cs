using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwap : MonoBehaviour
{
    public int levelNum;
    private int scene;

    void Start(){
        //scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        if(other.CompareTag("Player")){
            // if (scene == 1){
            // StartCoroutine(Intro());
            // }
            // else{
            SceneManager.LoadScene(levelNum);
            //}
        }    
    }


    // IEnumerator Intro(){
    //     Buttons.enabled = true;
    //     Debug.Log("Intro Started");
    //     Buttons.Play("level"+ levelNum.ToString(), 0,0.0f);
    //     yield return new WaitForSeconds(0.2f);
    //     source.Play();
    //     Debug.Log("about to wait");
    //     yield return new WaitForSeconds(WaitTime);
    //     SceneManager.LoadScene(levelNum);
    // }

}
