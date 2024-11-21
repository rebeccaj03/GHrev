using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneSwitch : MonoBehaviour
{

    public int levelnum;
    public void Playgame () {
        SceneManager.LoadScene(levelnum);
    }

    public void QuitGame () {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
