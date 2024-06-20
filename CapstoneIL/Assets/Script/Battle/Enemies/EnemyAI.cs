using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        Chasing
    }

    [SerializeField] private float detectionRange = 5f; // Jarak deteksi musuh ke pemain
    [SerializeField] private float roamInterval = 2f; // Interval waktu untuk perubahan arah acak

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Transform playerTransform;
    private Vector2 roamPosition;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(RoamingRoutine());
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRange)
        {
            state = State.Chasing;
        }
        else
        {
            state = State.Roaming;
        }

        if (state == State.Chasing)
        {
            enemyPathfinding.MoveTo(playerTransform.position - (Vector3)transform.position);
        }
    }

    private IEnumerator RoamingRoutine()
    {
        while (true)
        {
            if (state == State.Roaming)
            {
                roamPosition = GetRoamingPosition();
                enemyPathfinding.MoveTo(roamPosition);
            }

            yield return new WaitForSeconds(roamInterval);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return (Vector2)transform.position + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
