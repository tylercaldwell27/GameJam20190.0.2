//Amardeep Seeboruth
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    
    public static int scoreValue = 0;
    public Text score;
    
    // Start is called before the first frame update
    public void Start()
    {
        score.GetComponent<Text>();
        SwitchSences playAgian = new SwitchSences();
      
    }

    // Update is called once per frame
    public void Update()
    {
        score.text = "Score:" + scoreValue;
        Debug.Log("Score:" + scoreValue);
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            score.text = "Your Score Was:" + scoreValue;
            
            
        }

    }
}
