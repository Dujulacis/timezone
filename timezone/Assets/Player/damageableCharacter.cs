using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageableCharacter : MonoBehaviour, DamageTable
{

    public bool disableSimulation = false;
    Collider2D physicsCollider;

    Animator animator;

    public float _health = 100f;

    public bool _targetable = true;

    Rigidbody2D rb;
    public float playerHealth
    {
        set{
            if(value < _health){
                // animator.SetTrigger("hit");
            }

            _health = value;

            if(_health <=0){
                // animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get{
            return _health;
        }
    }

    public bool Targetable {get {return _targetable;}
    set{
        _targetable = value;
        if(disableSimulation){
            rb.simulated = false;
        }

        physicsCollider.enabled = value;
       }
    }


    void Start()
    {
        // Invincible = false;
        // animator = GetComponent<Animator>();

        // animator.SetBool("isAlive", true);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }


        public void OnHit(float damage, Vector2 knockback)
    {
        // if (Invincible == false){
            playerHealth -= damage;

            rb.AddForce(knockback, ForceMode2D.Impulse);

            // InvincEnabled();
        // }
    }

    public void OnObjectDestroyed(){
        Destroy(gameObject);
    }
}
