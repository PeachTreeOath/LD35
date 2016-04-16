using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Magnetized magnetized = collider.gameObject.GetComponent<Magnetized>();
        magnetized.magnet = gameObject;
    }

    protected void ResizeRadius()
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        collider.radius = 2; //TODO make this work the way its supposed to...
    }
}
