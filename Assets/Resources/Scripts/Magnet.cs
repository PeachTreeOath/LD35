using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Magnetized magnetized = collider.gameObject.GetComponent<Magnetized>();
        if(magnetized == null) {
            magnetized = collider.gameObject.AddComponent<Magnetized>();
        }

        GameObject parent = transform.parent.gameObject;
        magnetized.magnet = parent != null ? parent : gameObject;
    }

    protected void ResizeRadius()
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        collider.radius = 2; //TODO make this work the way its supposed to...
    }
}
