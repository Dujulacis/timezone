using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Collider2D bulletCollider;


    private void Start(){
        bulletCollider = GetComponent<Collider2D>();
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
        // else if (collision.gameObject.CompareTag("Bullet")){
        //     Physics.IgnoreCollision(gameObject.GetComponent<CharacterController>(), gameObject.GetComponent<Collider>());
        // }
    }
}
