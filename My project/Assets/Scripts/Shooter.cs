using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;   // assign in Inspector
    public GameObject cannonballPrefab;
    public Transform shootPoint;          // where the projectile spawns
    public Transform shootPointCannon;
    public float shootForce = 20f;

    private AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip cannonSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Fire with Space or Left Mouse
        if (Input.GetMouseButtonDown(0))
        {
            if (shootSound != null)
                audioSource.PlayOneShot(shootSound);
            else
                Debug.LogWarning("Shoot sound is not assigned in the Inspector!");
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cannonSound != null)
                audioSource.PlayOneShot(cannonSound);
            ShootCannon();
        }
    }

    void Shoot()
    {
        // Spawn projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Apply physics force
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);

        // Destroy after 5 sec (cleanup)
        Destroy(projectile, 5f);
    }
    void ShootCannon()
    {
        // Spawn projectile
        GameObject cannonball = Instantiate(cannonballPrefab, shootPointCannon.position, shootPointCannon.rotation);

        // Apply physics force
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        rb.AddForce(shootPointCannon.forward * shootForce, ForceMode.Impulse);

        // Destroy after 5 sec (cleanup)
        Destroy(cannonball, 5f);
    }
}
