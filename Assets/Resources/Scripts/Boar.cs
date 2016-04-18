using UnityEngine;
using System.Collections;
using System;

public class Boar : MonoBehaviour
{
    private bool boarActive;
    private bool boarRunningState;
    private bool boarOnGround;

    public float Value
    {
        get { return boarActive ? 1f : 0f; }
        set
        {
            bool prevValue = boarActive;
            boarActive = value > 0;

            if (boarActive != prevValue)
                OnStateChange(boarActive);
        }
    }

    void OnStateChange(bool newValue)
    {
        if (newValue)
        {
            StartBoar();
        }
        else
        {
            StopBoar();
        }
    }

    void StartBoar()
    {
    }

    void Update()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();

        if (boarActive && boarOnGround )
        {
            body.rotation = 0;
            body.velocity = new Vector2(body.velocity.x + 0.2f, 0);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            boarOnGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            boarOnGround = false;
        }
    }

    void StopBoar()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        if(boarOnGround)
        {
            body.AddForce(new Vector2(0, body.velocity.x), ForceMode2D.Impulse);
        }    
    }
}
