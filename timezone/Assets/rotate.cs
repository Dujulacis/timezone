using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform transformation;
    private Vector2 mousePosition;
    public Camera frameCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = frameCamera.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void FixedUpdate()
    {
        // //rotē ieroci pret peli
        // Vector2 aimDirection = mousePosition - rb.position;
        // float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        // transform.rotation = aimAngle;

        //rotē ieroci pret peli
        Vector2 aimDirection = mousePosition - new Vector2(transformation.position.x, transformation.position.y);
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, aimAngle);
        transformation.rotation = rotation;

        // Vector2 aimDirection = MouseFollow.position - transform.position;
        // float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        // transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);

    }
}
