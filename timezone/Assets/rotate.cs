using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform transformation;

    private Vector2 mousePosition;
    private Vector2 directionChange;

    public Camera frameCamera;

    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = frameCamera.ScreenToWorldPoint(Input.mousePosition);


        if ( Input.GetKeyDown(KeyCode.A) ){
            directionChange = transform.position;
            spriteRenderer.flipX = true;
            transform.position = new Vector3(directionChange.x -0.8f, directionChange.y +0.2f);
        }else if ( Input.GetKeyUp(KeyCode.A) ){
            directionChange = transform.position;
            transform.position = new Vector3(directionChange.x +0.8f, directionChange.y -0.2f);
        }else if ( Input.GetKeyDown(KeyCode.D) ){
            directionChange = transform.position;
            spriteRenderer.flipX = false;
            transform.position = new Vector3(directionChange.x +0.8f, directionChange.y +0.2f);
        }else if ( Input.GetKeyUp(KeyCode.D) ){
            directionChange = transform.position;
            transform.position = new Vector3(directionChange.x -0.8f, directionChange.y -0.2f);
        }
    }

    void FixedUpdate()
    {
        //rotē ieroci pret peli
        Vector2 aimDirection = mousePosition - new Vector2(transformation.position.x, transformation.position.y);
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, aimAngle);
        transformation.rotation = rotation;

    }
}
