using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float maxVerticalSpeed;
    private MasterScript masterScript;
    private int player1Score;
    private object player1ScoreText;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        masterScript = GameObject.Find("Canvas").GetComponent<MasterScript>();
    }

    void Start()
    {
        if (Settings.difficulty == Difficulty.Normal)
        {
            speed *= 2f;
            maxVerticalSpeed *= 2f;
        }
        else if (Settings.difficulty == Difficulty.Hard)
        {
            speed *= 3f;
            maxVerticalSpeed *= 2f;
        }
        if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
            speed = -speed;
        rb.velocity = new Vector2(speed, maxVerticalSpeed*UnityEngine.Random.Range(-1f,1f));

    }

    

    void Update()
    {
        //  if (Math.Abs(transform.position.y) > 4.75 && Math.Abs(rb.velocity.y > 0)) rb.velocity = new Vector2(speed, -rb.velocity.y);
        if (transform.position.y > 4.75 && rb.velocity.y > 0)
               rb.velocity = new Vector2(speed, -rb.velocity.y);
           else if (transform.position.y < -4.75 && rb.velocity.y < 0)
               rb.velocity = new Vector2(speed, -rb.velocity.y);

        if(transform.position.x > 9)
        {
            masterScript.AddScore(true);
            ResetBall();
        }
        else if (transform.position.x < -9)
        {
            masterScript.AddScore(false);
            ResetBall();
        }
     
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(transform.position.x > -8 && transform.position.x < 8)
        {
            speed = -speed;
            float difference = Mathf.Clamp(transform.position.y - other.transform.position.y, -0.4f, 0.4f) * 2.5f;
  
            //rb.valocity = new Vector2(speed, 0);
            rb.velocity *= -1;

            rb.velocity = new Vector2(speed, maxVerticalSpeed * difference);
        }
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;

        if (!MasterScript.gameEnded)
            rb.velocity = new Vector2(speed, 0); //maxVerticalSpeed * UnityEngine.Random.Range(-1f, 1f));
        else
            rb.velocity = Vector2.zero;
    }
}
