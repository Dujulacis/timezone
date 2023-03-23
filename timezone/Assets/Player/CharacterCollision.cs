using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Reverse the character's velocity
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = -rb.velocity;
        }
    }
}