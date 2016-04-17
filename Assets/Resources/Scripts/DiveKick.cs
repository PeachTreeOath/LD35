using UnityEngine;
using System.Collections;

public class DiveKick : MonoBehaviour {

    private bool diveKicking = false;
    private float savedSpeed = 0f;
    private State state = State.NONE;

    public PhysicsMaterial2D groundMaterial;
    public Vector2 DiveSpeed = Vector2.zero;
    public enum State { NONE, DIVING, RECOVERING }

    public float Value
    {
        get { return diveKicking ? 1f : 0f; }
        set {
            bool prevValue = diveKicking;
            diveKicking = value > 0;

            if (diveKicking != prevValue)
                OnStateChange(diveKicking);
        }
    }

    void OnStateChange(bool newValue) {
        if (newValue) {
            StartDive();
        }
        else {
            StopDive();
        }
    }

    void StartDive()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        Bounciness bounciness = gameObject.GetComponent<Bounciness>();

        savedSpeed = body.velocity.x;
        body.velocity = Vector2.zero;

        bounciness.NoBounce = true;
        state = State.DIVING;
    }

    void StopDive()
    {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        Bounciness bounciness = gameObject.GetComponent<Bounciness>();

        bounciness.NoBounce = false;

        state = State.NONE;
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        if (state == State.DIVING) {
            body.velocity.Set(DiveSpeed.x + savedSpeed, DiveSpeed.y);
        }
	}
    
}
