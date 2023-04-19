using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageableCharacter : MonoBehaviour, DamageTable
{

    public GameObject DamageNumbers;
    public bool disableSimulation = false;
    Collider2D physicsCollider;
    [SerializeField] float delayBeforeDestroy = 2f;
    Shooting shooting;
    Vector3 startPos;
    
    SpriteRenderer spriteRenderer;
    Animator animator;
    public bool canTurnInvincible = false;
    public float invincibilityTime = 0.25f;
    public float invincTimeElapsed = 0f;
    public bool Invincible {get {
        return _invincible;
    } set {
        _invincible = value;
        if (Invincible==true){
            invincTimeElapsed = 0f;
        }
     }
    }

    float _health = 100f;
    public bool _invincible = false;
    bool _targetable = true;

    public float score = 0;

    Rigidbody2D rb;
    public float playerHealth
    {
        set{
            if(value < _health){
                // animator.SetTrigger("hit");
                RectTransform textTransform = Instantiate(DamageNumbers).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.ScreenToWorldPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
                shooting = GetComponent<Shooting>();
            }

            _health = value;

            if(_health <=0){
                // animator.SetBool("isAlive", false);
                Targetable = false;
                OnObjectDestroyed();

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
        startPos = transform.position;
        Invincible = false;
        // animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // animator.SetBool("isAlive", true);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
    }


        public void OnHit(float damage, Vector2 knockback)
    {
        if (!Invincible){
            playerHealth -= damage;

            rb.AddForce(knockback, ForceMode2D.Impulse);

            if(canTurnInvincible){
                //activate invincibility and timer
                Invincible = true;
            }
        }
    }

    public void OnObjectDestroyed(){
        gameObject.SetActive(false);
        Invoke("Respawn", delayBeforeDestroy);
        if(gameObject.tag=="Enemy"){
            score += 100;
            Debug.Log(score);
                }
    }

    public void FixedUpdate(){
        if (Invincible){
            invincTimeElapsed += Time.deltaTime;

            if (invincTimeElapsed > invincibilityTime){
                Invincible = false;
            }
        }
    }

    void Respawn(){

        _health = 100f;
        gameObject.SetActive(true);
        rb.simulated = true;
        physicsCollider.enabled = true;
        rb.transform.position = new Vector3(Random.Range(startPos.x - 1,startPos.x +1), Random.Range(startPos.y -1, startPos.y +1), startPos.z);
    
        if (gameObject.CompareTag("Player")){
            Shooting.shouldReload = true;
        }

        
        //respawn enemy
    }
}
