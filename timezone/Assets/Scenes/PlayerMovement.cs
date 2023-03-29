// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed;
//     public Camera frameCamera;
//     public Rigidbody2D rb;

//     private Vector2 moveDirection;

//     private Vector2 mousePosition;


//     // Update is called once per frame
//     void Update()
//     {
//       //processing inputs 
//       ProcessInputs();  
//     }

//     void FixedUpdate()
//     {
//         //physics simulations
//         Move();
//     }

//     void ProcessInputs()
//     {
//         float moveX = Input.GetAxisRaw("Horizontal");
//         float moveY = Input.GetAxisRaw("Vertical");

//         moveDirection = new Vector2(moveX, moveY).normalized; 
//         mousePosition = frameCamera.ScreenToWorldPoint(Input.mousePosition);
//     }
    
//     void Move()
//     {
//         rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

//         //rotē spēlētāju pret peli
//         Vector2 aimDirection = mousePosition - rb.position;
//         float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
//         rb.rotation = aimAngle;
//     }

// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed ;
    public Camera frameCamera;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    private Vector2 mousePosition;


    private float invincCooldown = 1.0f;

    public bool Invincible;

    public float health;
    public float maxHealth = 100;


    //Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        Invincible = false;
    }


    public float Health
    {
        set{
            // if (value < health){
            //     animator.SetTrigger("hit");

            //     RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
            //     textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            //     Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            //     textTransform.SetParent(canvas.transform);
            // }
            health = value;

            if(health <=0){
                // animator.SetBool("isAlive", false);
                Destroy(gameObject);
            }
        }
        get{
            return health;
        }
    }


    public void InvincEnabled()
    {
        Invincible = true;
        StartCoroutine(InvincDisableRoutine());
    }


    IEnumerator InvincDisableRoutine()
    {
        yield return new WaitForSeconds(invincCooldown);
        Invincible = false;
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 
        mousePosition = frameCamera.ScreenToWorldPoint(Input.mousePosition);
    }


        void FixedUpdate()
    {
        //physics simulations
        Move();
    }

    // Update is called once per frame
    void Update()
    {
      //processing inputs 
      ProcessInputs();  
    }


    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //rotē spēlētāju pret peli
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }


    public void OnHit(float damage, Vector2 knockback)
    {
        if (Invincible == false){
            Health -= damage;

            rb.AddForce(knockback, ForceMode2D.Impulse);

            InvincEnabled();
        }
    }


    // public void OnHit(float damage, Vector2 knockback)
    // {
    //     if (!Invincible){
    //         Health -= damage;

    //         if(canTurnInvincible){
    //             Invincible = true;
    //         }
    //     }
    // }

}
