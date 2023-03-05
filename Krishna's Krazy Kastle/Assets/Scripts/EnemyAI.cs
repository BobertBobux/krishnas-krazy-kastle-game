using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Moving,
        Death
    }

    [SerializeField] private GameObject playerObject;
    [SerializeField] private int health;
    [SerializeField] private float movementSpeed;

    private float distanceFromPlayer;
    private EnemyState currentState;

    void Start()
    {
        currentState = EnemyState.Moving;
}

    void Update()
    {
        CheckHealth();

        switch (currentState)
        {
            case EnemyState.Moving:
                MovementBehaviour();
                break;
            case EnemyState.Death:
                DeathBehaviour();
                break;
        }
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            currentState = EnemyState.Death;
        }
    }

    private void MovementBehaviour()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, playerObject.transform.position);
        Vector2 direction = playerObject.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, playerObject.transform.position, movementSpeed * Time.deltaTime);
    }

    private void DeathBehaviour()
    {
        GetComponent<ItemDropPool>().InstantiateItem(transform.position);
        Destroy(gameObject);
    }
}
