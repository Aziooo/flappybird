using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed;

    public float startSpeed = 3f;

    public float endSpeed = 10.0f;

    public float duration = 30.0f;

    private float leftEdge;


    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
        
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float timeElapsed = Time.time;

        float t = Mathf.Clamp01(timeElapsed / duration);

        speed = Mathf.Lerp(startSpeed, endSpeed, t);

        //Pipes movement
        transform.position += Vector3.left * speed * Time.deltaTime;

        //Destroy pipes when they leave the screen
        if (transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }
}
