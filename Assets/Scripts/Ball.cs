using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float startVelocityX, startVelocityY;
    [SerializeField] AudioClip[] ballHit;
    [SerializeField] float randomnessLimitX, randomnessLimitY;



    Vector2 PaddleBallVec;

    bool isStarted = false;

    AudioSource myAuSource;
    Rigidbody2D myRigidBody2D;


    void Start()
    {
        PaddleBallVec = transform.position - paddle.transform.position;
        myAuSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            ballLock();
            pushBall();
        }

    }


    private void ballLock()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = (paddlePos + PaddleBallVec);
    }

    private void pushBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            myRigidBody2D.velocity = new Vector2 (startVelocityX, startVelocityY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 randomVelocity = new Vector2(Random.Range(0f, randomnessLimitX), Random.Range(0f, randomnessLimitY));
        if (isStarted)
        {
            AudioClip clip = ballHit[Random.Range(0, ballHit.Length)];
            myAuSource.PlayOneShot(clip);
            myRigidBody2D.velocity += randomVelocity;
        }
    }  
}
