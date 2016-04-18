using UnityEngine;
using System.Collections;
using System;

public class Umbrella : MonoBehaviour
{
    private bool umbrellaActive;
    private float oldGravity;

    public float Value
    {
        get { return umbrellaActive ? 1f : 0f; }
        set
        {
            bool prevValue = umbrellaActive;
            umbrellaActive = value > 0;

            if (umbrellaActive != prevValue)
                OnStateChange(umbrellaActive);
        }
    }

    void OnStateChange(bool newValue)
    {
        if (newValue)
        {
            StartUmbrella();
        }
        else
        {
            StopUmbrella();
        }
    }

    void StartUmbrella()
    {
        
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        oldGravity = body.gravityScale;
        body.gravityScale = 0;
        body.rotation = 0;
        body.velocity = new Vector2(body.velocity.x, 0);
        Debug.Log("Start umbrella " + oldGravity.ToString());
    }

    void StopUmbrella()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.gravityScale = oldGravity;
        Debug.Log("Stop umbrella " + body.gravityScale.ToString());
    }
}
