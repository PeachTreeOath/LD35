using UnityEngine;
using System.Collections;

public class DiveKick : MonoBehaviour {

    private bool diveKicking = false;
    private float savedSpeed = 0f;
	private float diveMult = 800f;
	private State state = State.NONE;

    public PhysicsMaterial2D groundMaterial;
	public Vector2 diveSpeed;
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
		diveSpeed = new Vector2 (diveMult, -diveMult);
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
			body.velocity = Vector2.zero;
			body.AddForce(new Vector2(diveSpeed.x + savedSpeed, diveSpeed.y));
        }
	}
    
}
