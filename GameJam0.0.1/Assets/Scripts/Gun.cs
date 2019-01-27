
// coded by Tyler

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate = 0;
    public float Damage = 30;
    public LayerMask whatToHit;

    public Transform BulletTrailPrefab;

    float timeToFire = 0;
    Transform firePoint;
    EnemyHealthSystem enemyDamage = new EnemyHealthSystem();
    // Start is called before the first frame update
    void Awake()
    {

        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint?");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }



            }
        }
    }
    void Shoot()
    {

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        Effect();

        // Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100,Color.cyan);  
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.tag == "Generic")
            {
                EnemyHealthSystem enemyHealthScript = hit.transform.GetComponent<EnemyHealthSystem>();
                enemyHealthScript.DeductHealth(Damage);
             
            }


            // Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
        else
        {
            Debug.Log("miss");
        }
    }



    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}
