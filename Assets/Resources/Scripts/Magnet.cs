using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

    private float range;
    private float rangeToWorldMult = 1;

    public float Range
    {
        get { return range;  }
        set
        {
            range = value;
            ResizeRadius();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (range > 0)
        {
            Magnetized magnetized = collider.gameObject.GetComponent<Magnetized>();
            if (magnetized == null)
            {
                magnetized = collider.gameObject.AddComponent<Magnetized>();
            }

            GameObject parent = transform.parent.gameObject;
            magnetized.magnet = parent != null ? parent : gameObject;
        }
    }

    public void SetRange(float range)
    {
        this.range = range;

    }

    protected void ResizeRadius()
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        collider.radius = range * rangeToWorldMult;
    }
}
