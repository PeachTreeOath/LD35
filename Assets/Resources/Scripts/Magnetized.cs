using UnityEngine;
using System.Collections;

public class Magnetized : MonoBehaviour {

    public GameObject magnet;

    public float stiffness = 100f;
    public float damping = 25f;
    public float maxSpeed = 25f;

	void LateUpdate () {
        if (magnet == null) return;

        Rigidbody2D myBody = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D magnetBody = magnet.GetComponent<Rigidbody2D>();

        if(myBody != null && magnetBody != null) 
        {
            Vector2 delta = magnetBody.position - myBody.position;
            Vector2 acceleration = delta * stiffness - myBody.velocity;

            myBody.velocity = Vector2.ClampMagnitude(myBody.velocity + acceleration * Time.deltaTime, maxSpeed);
        }
    }
}
