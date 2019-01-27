
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSystem : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float attackDmg;
    public float AttackSpeed;

    [SerializeField]
    private float flashLength;

    private float flashCounter;

    Renderer render;
    private Color defaultColor;
    ScoreScript sc;
    void Start()
    {
        
        currentHealth = health;
        render = GetComponent<Renderer>();
        defaultColor = render.material.GetColor("_Color");
    }

     public void Update()
     {
        if (health <= 0)
        {
            
            EnemyDead();
        }
        

        if (flashCounter > 0.0f)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0.0f)
            {
                render.material.SetColor("_Color", defaultColor);
            }
        }
     }

    public void DeductHealth(float deductHealth)
    {
        Debug.Log(health);
        
        health -= attackDmg;
        flashCounter = flashLength;
        render.material.SetColor("_Color", Color.red);
    }

    void EnemyDead()
    {
        ScoreScript.scoreValue += 10;
        Destroy(gameObject);
    }
    
      
}    