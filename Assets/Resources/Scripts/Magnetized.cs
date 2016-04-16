using UnityEngine;
using System.Collections;

public class Magnetized : MonoBehaviour {

    public GameObject magnet;

    public float stiffness = 100f;
    public float damping = 50f;
    public float minimumDistance = 25f;

	void LateUpdate () {
        if (magnet == null) return;

        Rigidbody2D myBody = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D magnetBody = magnet.GetComponent<Rigidbody2D>();

        if(myBody != null && magnetBody != null) 
        {
            Vector2 delta = magnetBody.position - myBody.position - new Vector2(minimumDistance, minimumDistance);
            Vector2 acceleration = delta * stiffness - myBody.velocity * damping;

            myBody.velocity += acceleration * Time.deltaTime;
        }
    }
}
