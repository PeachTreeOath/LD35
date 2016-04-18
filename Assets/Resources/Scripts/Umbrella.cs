using UnityEngine;
using System.Collections;

public class Umbrella : MonoBehaviour
{
    private bool umbrellaActive;
    private float oldGravity;

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.gravityScale = 0;
    }


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
            StartDive();
        }
        else
        {
            StopDive();
        }
    }

    void StartDive()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        oldGravity = body.gravityScale;
        body.gravityScale = 0;
    }

    void StopDive()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.gravityScale = oldGravity;
    }
}
