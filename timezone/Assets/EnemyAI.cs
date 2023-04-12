using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public Transform target;

    public float enemyDamage = 34f;

    public float knockbackForce = 100f;
    public float movespeed = 500f;

    private Rigidbody2D rb;

    public float health = 100;

    public float Health
    {
        set{
            health = value;

            if(health <=0){

                Defeated();
            }
        }
        get{
            return health;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move towards the target
        Vector2 direction = (target.position - transform.position).normalized;
        rb.AddForce(direction * speed);

        // Limit the speed
        if (rb.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

    }

    
    // void OnCollisionEnter2D(Collision2D collision){
    //     Collider2D collider = collision.collider;
    //     DamageTable damageable =collider.GetComponent<DamageTable>();
    //     if (damageable != null){

    //         //changes the collision force direction
    //         Vector2 direction = (collider.transform.position - transform.position).normalized;

    //         Vector2 knockback = direction * knockbackForce;

    //         damageable.OnHit(damage, knockback);
    //     }
    // }


    public void Defeated(){
        Destroy(gameObject);
    }
}

