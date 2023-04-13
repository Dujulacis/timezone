using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage = 10f;
    public Collider2D bulletCollider;
    public GameObject player;
    public float knockbackForce = 100000f;

    private void Start(){
        bulletCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    IEnumerator DespawnTimer(){
        yield return new WaitForSeconds(0.500F);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.CompareTag("Obstacle")){
            StartCoroutine(DespawnTimer());
                Vector2 direction = (GetComponent<Collider2D>().transform.position - transform.position).normalized;
                Vector2 knockback = direction * knockbackForce;
                float angle = Random.Range(-7, 7); // maxAngleDeviation is the maximum angle deviation from the original direction
        }
        
        else if (collision.gameObject.CompareTag("Enemy")){
            // StartCoroutine(DespawnTimer());
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();

            if (enemy != null){
                enemy.Health -= damage;

            }
            bulletCollider.enabled = false;
            StartCoroutine(DespawnTimer());
        }
        
    }
}
