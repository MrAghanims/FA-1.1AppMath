using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float scaleSpeed = 2f;
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public int points = 10;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Pulsate (scale up and down)
        float scale = 1 + Mathf.Sin(Time.time * scaleSpeed) * .1f;
        transform.localScale = new Vector3(scale, scale, scale);

        // Move side to side
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
    public void KillEnemy()
    {
        ScoreManager.Instance.AddScore(points);
        Destroy(gameObject);
    }
}