using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float currentSpeed = 0;

    public bool isAttack = true;

    [SerializeField] private float attackCooldown = 1;

    public Vector2 movementInput {get; set;}

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }





    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (movementInput.magnitude > 0.1f && currentSpeed >= 0)
        {
            rb.velocity = movementInput * currentSpeed;

            if (movementInput.x < 0)
            {
                sr.flipX = false;
            }

            if (movementInput.x > 0)
            {
                sr.flipX = true;
            }

        }
        else 
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Attack()
    {
        if (isAttack)
        {
            isAttack = false;

            StartCoroutine(nameof(AttackCoroutine));
        }
    }

    IEnumerator AttackCoroutine()
    {
        anim.SetTrigger("isAttack");
        
        yield return new WaitForSeconds(attackCooldown);

        isAttack = true;
    }
}
