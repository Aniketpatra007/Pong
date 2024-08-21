using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private float startSpeed = 5f;
    private float extraSpeed = 0.5f;
    private float maxExtraSpeed = 15f;
    public bool player1Start = true;

    private int hitCounter = 0;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
    public void SetStartSpeed(float speed)
    {
        startSpeed = speed;
    }

    public IEnumerator Launch()
    {
        RestartBall();
        yield return new WaitForSeconds(1);
        if (player1Start)
        {
            SetStartSpeed(5);
            MoveBall(new Vector2(-1, 0));
            
        }
        else
        {
            SetStartSpeed(5);
            MoveBall(new Vector2(1, 0));
        }
    }
    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;    
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter*extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
