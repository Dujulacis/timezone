using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;

    public float bounceSpeedReduction = 0.9f;
    public Collider2D bulletCollider;
    public GameObject player;
    public float knockbackForce = 100f;

    public Rigidbody2D rb;

    private void Start(){
        bulletCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator DespawnTimer(){
        yield return new WaitForSeconds(0.500F);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.CompareTag("Obstacle")){
            StartCoroutine(DespawnTimer());

            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;
            Vector2 reflection = Vector2.Reflect(rb.velocity.normalized - normal, normal) + Random.insideUnitCircle * 0.5f;
            // Vector2 reflection = Vector2.Reflect(transform.position - contactPoint, normal).normalized + Random.insideUnitCircle * 0.1f;
            

            rb.velocity = reflection * (rb.velocity.magnitude * bounceSpeedReduction);

        }
        
        else if (collision.gameObject.CompareTag("Enemy")){
            // StartCoroutine(DespawnTimer());
            damageableCharacter enemy = collision.gameObject.GetComponent<damageableCharacter>();
            

            if (enemy != null){
                enemy.playerHealth -= damage;

            }
            bulletCollider.enabled = false;
            StartCoroutine(DespawnTimer());
        }
        
    }
}
