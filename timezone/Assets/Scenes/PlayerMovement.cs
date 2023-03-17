using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Camera frameCamera;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    private Vector2 mousePosition;


    // Update is called once per frame
    void Update()
    {
      //processing inputs 
      ProcessInputs();  
    }

    void FixedUpdate()
    {
        //physics simulations
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 
        mousePosition = frameCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //rotē spēlētāju pret peli
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

}
