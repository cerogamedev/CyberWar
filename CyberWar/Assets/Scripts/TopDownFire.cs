using System.Collections;
using UnityEngine;

public class TopDownFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Check for fire input and fire bullets
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Fire();
        }
    }

    void Fire()
    {
        // Get the mouse position in the world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calculate the direction from the firePoint to the mouse position
        Vector3 fireDirection = (mousePos - firePoint.transform.position).normalized;

        // Instantiate a bullet at the position and rotation of the firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Set the velocity of the bullet to the calculated direction
        rb.velocity = fireDirection * bulletSpeed;

        // Destroy the bullet after a certain time (adjust as needed)
        Destroy(bullet, 2f);
    }
}
