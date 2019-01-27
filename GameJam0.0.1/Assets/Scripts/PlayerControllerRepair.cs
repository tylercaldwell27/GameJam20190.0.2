/*
 * Rhainel Peralta
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerRepair : MonoBehaviour
{
    // Movement of the player
    public float moveSpeed = 5.0f;

    [SerializeField] bool atSecondFloorDoor = false;
    [SerializeField] bool atFirstFloorDoor = false;
    public Transform doorUpstairs;
    public Transform doorDownstairs;
    public float teleportoffset = 1.61f;

    public float repairCoolDownTime = 3f;
    //[SerializeField] bool isRepairing = false;
    [SerializeField] bool isNearLeftWall = false;
    [SerializeField] bool isNearRightWall = false;
    public Transform leftWall;
    public Transform rightWall;

    // Custom Keys used to move player
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Interact;

    // Players Body
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //Input
        if (Input.GetKey(Left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(Right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(Up))
        {
            if (atSecondFloorDoor)
            {
                //player goes to 1st floor
                //this.transform.position = doorDownstairs.position;
                this.transform.Translate(0, -teleportoffset, 0);
                Debug.Log("Player is at 2nd Floor Door");
            }

            if (atFirstFloorDoor)
            {
                // player goes to 2nd floor
                //this.transform.position = doorUpstairs.position;
                this.transform.Translate(0, teleportoffset, 0);
                Debug.Log("Player is at 1st Floor Door");
            }

            if (!atFirstFloorDoor)
            {
                Debug.LogWarning("Player is NOT at First Floor door");
            }
            if (!atSecondFloorDoor)
            {
                Debug.LogWarning("Player is NOT at Second Floor door");
            }
            if (!atFirstFloorDoor && !atSecondFloorDoor)
            {
                Debug.LogWarning("Player is NOT at  door");
            }
        }

        // Repair skill
        if (Input.GetKeyDown(Interact))
        {
            
            if (isNearLeftWall)
            {
                if (leftWall.GetComponent<WallHealth>().health < 500f)
                {
                    StartCoroutine("RepairCoolDown");
                    Repair(isNearLeftWall, isNearRightWall);
                }
            }
            else { Debug.LogWarning("Not near a wall"); }

            if (isNearRightWall)
            {
                if (rightWall.GetComponent<WallHealth>().health < 500f)
                {
                    StartCoroutine(RepairCoolDown());
                    //Repair(isNearLeftWall, isNearRightWall);
                }
            }
            else { Debug.LogWarning("Not near a wall"); }


        }   
    }

    IEnumerator RepairCoolDown()
    {
        yield return new WaitForSeconds(repairCoolDownTime);
        Repair(isNearLeftWall, isNearRightWall);
    }
    void Repair(bool lWall, bool rWall)
    {
        // add health to the wall
        if (lWall)
        {
            leftWall.GetComponent<WallHealth>().health = 500.0f;
        }
        if (rWall)
        {
            rightWall.GetComponent<WallHealth>().health = 500.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "LeftWall")
        {
            isNearLeftWall = true;
        }
        if (col.gameObject.tag == "RightWall")
        {
            isNearRightWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "LeftWall")
        {
            isNearLeftWall = false;
        }
        if (col.gameObject.tag == "RightWall")
        {
            isNearRightWall = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorFirstFloor")
        {
            atFirstFloorDoor = true;
        }
        if (col.gameObject.tag == "DoorSecondFloor")
        {
            atSecondFloorDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "DoorFirstFloor")
        {
            atFirstFloorDoor = false;
        }
        if (col.gameObject.tag == "DoorSecondFloor")
        {
            atSecondFloorDoor = false;
        }
    }
}
