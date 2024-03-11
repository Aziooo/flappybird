using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    protected override void OnEnable()
    {
        Vector3 position = transform.position;

        position.y = 0f;

        position.x = -2f;

        transform.position = position;

        direction = Vector2.zero;
        
        transform.localScale = Vector3.one;
    }
    // Update is called once per frame
    protected override void Update()
    {

        // Detect player input for  movement.
        float moveX = Input.GetAxis("HorizontalJoy");

        float moveY = Input.GetAxis("JumpJoy") * jumpStrength;

        Vector2 moveDirection = new Vector2(moveX, moveY);

        rb.velocity = moveDirection * speed;
        



    }



}
