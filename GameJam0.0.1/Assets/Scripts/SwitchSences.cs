using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchSences : MonoBehaviour
{
    public bool reset = false;
    // when the play button is pressed
    public void StartGame(){
        //gets the active scene from the buildIndex and plays the next scene after
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }
    //quitting game
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back(){
        //gets the active scene from the buildIndex and plays the next scene after
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        reset = true;

    }
    
}
