using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed ;
    public Camera frameCamera;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    // public float knockbackForce = 10000f;
    private float invincCooldown = 1.0f;

    public bool Invincible = false;

    Animator animator;

    SpriteRenderer spriteRenderer;


    //Start is called before the first frame update
    void Start()
    {
        Invincible = false;
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);            
        }

        if ( Input.GetKey(KeyCode.D) ){
            spriteRenderer.flipX = true;
        } else if ( Input.GetKey(KeyCode.A) ){
            spriteRenderer.flipX = false;
        }

        if (Input.GetMouseButtonDown(0)){
            moveSpeed = moveSpeed * 0.5f;
        } else if (Input.GetMouseButtonUp(0)){
            moveSpeed = moveSpeed*2f;
        }
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
    }




 
}

//void OnCollisionEnter2D(Collision2D collision){
//     Collider2D collider = collision.collider;
//     DamageTable damageable =collider.GetComponent<DamageTable>();
//     if (damageable != null && !Invincible){
//         Vector2 direction = (collider.transform.position - transform.position).normalized;
//         Vector2 knockback = direction * knockbackForce;
//         damageable.OnHit(0,Vector2.zero);

//         InvincEnabled();
//     }
// }

   // public void OnHit(float damage, Vector2 knockback)
    // {
    //     if (!Invincible){
    //         Health -= damage;

    //         if(canTurnInvincible){
    //             Invincible = true;
    //         }
    //     }
    // }


    // public float Health
    // {
    //     set{
    //         // if (value < health){
    //         //     animator.SetTrigger("hit");

    //         //     RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
    //         //     textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    //         //     Canvas canvas = GameObject.FindObjectOfType<Canvas>();
    //         //     textTransform.SetParent(canvas.transform);
    //         // }
    //         health = value;

    //         if(health <=0){
    //             // animator.SetBool("isAlive", false);
    //             Destroy(gameObject);
    //         }
    //     }
    //     get{
    //         return health;
    //     }
    // }