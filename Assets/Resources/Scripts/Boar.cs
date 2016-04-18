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
        if(body.position.y < -3.3)
        { boarOnGround = true; }
        else { boarOnGround = false; }

        if (boarActive && boarOnGround )
        {
            body.rotation = 0;
            body.velocity = new Vector2(body.velocity.x + 0.3f, 0);
        }
        
    }

    void StopBoar()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.position = new Vector2(body.position.x, -3.28f);
        body.AddForce(new Vector2(0, body.velocity.x), ForceMode2D.Impulse);
    }
}
