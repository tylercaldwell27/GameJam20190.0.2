using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5f;
    public float temp;
    private Transform target;
    public LayerMask ignoreCol;

    [SerializeField] bool atFirstFloorDoor;
    public float teleportoffset = 1.61f;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        temp = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!atFirstFloorDoor)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (atFirstFloorDoor)
        {
            this.transform.Translate(0, -teleportoffset, 0);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // if the player has hit the enemy
        if (other.gameObject.tag == "LeftWall" || other.gameObject.tag == "RightWall")
        {
            speed = 0;
        }
        if (other.gameObject.tag == "Generic")
        {
            Physics2D.IgnoreLayerCollision(11, 11);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        // if the player has hit the enemy
        if (other.gameObject.tag == "LeftWall" || other.gameObject.tag == "RightWall")
        {
            speed = temp;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorFirstFloor")
        {
            atFirstFloorDoor = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorFirstFloor")
        {
            atFirstFloorDoor = false;
        }
    }
}