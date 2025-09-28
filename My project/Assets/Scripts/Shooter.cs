using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;   // assign in Inspector
    public Transform shootPoint;          // where the projectile spawns
    public float shootForce = 20f;

    void Update()
    {
        // Fire with Space or Left Mouse
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
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
}
