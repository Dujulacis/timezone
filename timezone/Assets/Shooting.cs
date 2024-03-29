using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    
    [SerializeField] public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float bulletForce = 20f;
    private float fireTime;

    public int shotsFired;
    public int maxShots = 30;
    static public bool shouldReload = false;
    public float reloadTime = 1.5f;
    public bool isReloading = false;

    public int ammoCount;
    public TextMeshProUGUI ammoDisplay;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireTime && !isReloading)
        {
            Shoot();
            shotsFired++;
            ammoCount = maxShots-shotsFired;
            ammoDisplay.text = ammoCount.ToString() + "/" + maxShots.ToString();
            if (shotsFired >= maxShots)
            {
                StartCoroutine(Reload());
            }
            else
            {
                fireTime = Time.time + fireRate;
            }
        }
        if (shouldReload == true){
            reloadTime = 0.1f;
            StartCoroutine(Reload());
            reloadTime = 3f;
            shouldReload =false;
            Debug.Log("Should reload recieved");
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(new Vector3(0, 0, -90)));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        float angle = Random.Range(-7, 7); // maxAngleDeviation is the maximum angle deviation from the original direction
        Vector2 direction = Quaternion.Euler(0, 0, angle) * firePoint.up; // add random angle deviation to the bullet direction
        rb.AddForce(direction * bulletForce);
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        shotsFired = 0;
        isReloading = false;
        ammoCount = maxShots;
        ammoDisplay.text = ammoCount.ToString() + "/" + maxShots.ToString();
    }
} 