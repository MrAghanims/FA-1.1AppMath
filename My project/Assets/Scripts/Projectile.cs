using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBehavior>().KillEnemy();
            Destroy(collision.gameObject); // destroy enemy
            Destroy(gameObject);           // destroy projectile
        }
    }
}