using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementInput;

    public UnityEvent OnAttack;

    [SerializeField] private Transform player;

    [SerializeField] private Transform player2;

    [SerializeField] private float chaseDistance = 3f;

    [SerializeField] private float attackDistance = 0.8f;

    protected Vector2 direction;

    public float attackCooldown = 1;

    public LayerMask playerLayer;

    public float attackCooldownDuration = 2f;


    public void MeleeAttackAnimEvent()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackDistance, playerLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    public void OnEnable()
    {
        Vector3 position = transform.position;

        position.y = 0f;

        position.x = 3f;

        transform.position = position;

        direction = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (player ==null)
        {
        return;
        }


        float distance = Mathf.Min(Vector2.Distance(player.position, transform.position),Vector2.Distance(player2.position, transform.position));

        // chase or attack, or if its out of range, do nothing
        if (distance < chaseDistance)
        {
            if (distance <= attackDistance) 
            {
                OnMovementInput?.Invoke(Vector2.zero);

                OnAttack?.Invoke();
            }
            else
            {
                Vector2 direction = player2.position - transform.position;
                if (Vector2.Distance(player.position, transform.position) > Vector2.Distance(player2.position, transform.position))
                {
                    direction = player2.position - transform.position;
                }
                else
                {
                    direction = player.position - transform.position;
                }
                
                OnMovementInput?.Invoke(direction.normalized);
            }
        }
        else
        {
            OnMovementInput?.Invoke(Vector2.zero);
        }
    }


}
