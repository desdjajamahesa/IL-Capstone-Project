using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float detectionRange = 5f; // Jarak deteksi musuh ke pemain
    [SerializeField] private float wanderRadius = 3f; // Radius untuk gerakan acak
    [SerializeField] private float wanderInterval = 2f; // Interval waktu untuk perubahan arah acak

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 wanderDirection;
    private float wanderTimer;
    private EnemyPathfinding enemyPathfinding;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyPathfinding = GetComponent<EnemyPathfinding>();
    }

    private void Start()
    {
        // Temukan objek dengan tag "Player" untuk mendapatkan transform pemain
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        wanderTimer = wanderInterval;
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(rb.position, playerTransform.position);

        if (distanceToPlayer <= detectionRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Wander();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (playerTransform != null)
        {
            enemyPathfinding.MoveTo(playerTransform.position);
        }
    }

    private void Wander()
    {
        wanderTimer += Time.fixedDeltaTime;

        if (wanderTimer >= wanderInterval)
        {
            wanderDirection = (Random.insideUnitCircle * wanderRadius).normalized;
            wanderTimer = 0;
        }

        Vector2 newPosition = rb.position + wanderDirection * enemyPathfinding.MoveSpeed * Time.fixedDeltaTime;
        enemyPathfinding.MoveTo(newPosition);
    }
}
