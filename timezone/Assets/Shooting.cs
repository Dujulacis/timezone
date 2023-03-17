using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float bulletForce = 20f;
    private float fireTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        fireTime = Time.time + fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint.up * bulletForce);
    }
}