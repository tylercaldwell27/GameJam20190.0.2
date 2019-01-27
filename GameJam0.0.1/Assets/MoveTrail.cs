using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{
    public int moveSpeed = 150;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1);


    }
    void OnCollisionEnter2D(Collision2D other)
    {

        // if the player has hit the enemy
        if (other.gameObject.tag == "Generic")
        {
            Destroy(gameObject, 0);
        }
    }
   
    
        
    
}
