using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    
    protected int spriteIndex;

    protected Vector2 direction;

    public float jumpStrength = 8.0f;

    public float speed = 8.0f;

    protected Rigidbody2D rb;

    protected Vector2 moveDirection;

    public float rotationSpeed = 5f; // Speed of rotation

    public float gravity = -15f;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    protected virtual void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnEnable()
    {

        
    }
    
    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected void FixedUpdate()
    {
        // Get the vertical velocity of the Rigidbody
        float verticalVelocity = rb.velocity.y;

        // Calculate the rotation angle based on the vertical velocity
        float rotationAngle = Mathf.Clamp((verticalVelocity * rotationSpeed) + gravity, -90f, 90f);

        // Apply the rotation to the sprite
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);

                
    }

    // Loop the animation sprites
    protected virtual void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }


    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        // if the player hits the wall, game is over; 
        // if the player touches the star, player gets bigger
        if (other.gameObject.tag == "Obstacle") {

            FindObjectOfType<GameManager>().GameOver();
            
        } else if (other.gameObject.tag == "Star")
        { 
            transform.localScale *= 1.1f;
            
            Destroy(other.gameObject);
        }
    }


}
