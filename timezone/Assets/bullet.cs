using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Collider2D bulletCollider;
    public GameObject player;

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
            Destroy(gameObject);
        }
        
        else if (collision.gameObject.CompareTag("Enemy")){
            StartCoroutine(DespawnTimer());
        }
        
    }
}
