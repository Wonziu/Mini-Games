using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float BallSpeed;

    private Rigidbody2D myRigidbody2D;
    private Vector2 lastVelocity;

    void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        myRigidbody2D.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    public void StartBall()
    {
        int r = Random.Range(0, 2);

        if (r == 1)
            myRigidbody2D.velocity = new Vector2(0, BallSpeed);
        else myRigidbody2D.velocity = new Vector2(0, BallSpeed * -1);

        lastVelocity = myRigidbody2D.velocity;
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.tag == "Wall")
        {
            myRigidbody2D.velocity = new Vector2(lastVelocity.x * -1, lastVelocity.y);
            lastVelocity = myRigidbody2D.velocity;
        }
        else if (hit.collider.tag == "Player")
        {
            float dist = transform.position.x - hit.transform.position.x;

            myRigidbody2D.velocity = new Vector2(dist * BallSpeed / 1.5f, lastVelocity.y * -1);
            lastVelocity = myRigidbody2D.velocity;
        }
    }
}
