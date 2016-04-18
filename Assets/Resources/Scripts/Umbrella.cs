using UnityEngine;
using System.Collections;

public class Umbrella : MonoBehaviour
{
    private bool umbrellaActive;
    private float oldGravity;
    private float oldDrag;

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
        oldDrag = body.drag;
        body.gravityScale = 0;
        body.drag = 0;
        Debug.Log("Start umbrella " + oldGravity.ToString());
    }

    void StopUmbrella()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        body.gravityScale = oldGravity;
        body.drag = oldDrag;
        Debug.Log("Stop umbrella " + body.gravityScale.ToString());
    }
}
