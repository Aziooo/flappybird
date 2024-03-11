using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    protected override void OnEnable()
    {

        Vector3 position = transform.position;

        position.y = 0f;

        position.x = 0f;

        transform.position = position;

        direction = Vector3.zero;
        
        transform.localScale = new Vector3(2,2,1);
        
    }
    // Update is called once per frame
    protected override void Update()
    {
        // Detect player input for movement.
        float moveX = Input.GetAxis("Horizontal");

        float moveY = Input.GetAxis("Jump") * jumpStrength;

        Vector2 moveDirection = new Vector2(moveX, moveY);

        rb.velocity = moveDirection * speed;
        

    }



}
