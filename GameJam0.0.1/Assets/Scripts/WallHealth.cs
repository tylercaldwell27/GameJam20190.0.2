using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour
{
    public float health = 500.0f;
    public float NextHit = 0.0f;
    public EnemyHealthSystem enemy;
    [SerializeField] bool attacked = false;


    // Update is called once per frame
    void Update()
    {
        if (attacked)
        {
            TakeDamage();
            Debug.Log(health);
        }

        if (health <= 0.0f)
        {
            this.gameObject.SetActive(false);
            //add wall crumbling anim
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        // if the player has hit the enemy
        if (other.gameObject.tag == "Generic")
        {
            attacked = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        attacked = false;
    }


    public void TakeDamage()
    {
        if (Time.time > NextHit)
        {
            NextHit = Time.time + enemy.AttackSpeed;
            health = health - enemy.attackDmg; ;//subtracts the amoutn of damage done from the players health
        }
    }
}
