using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Magnet : MonoBehaviour {

    private float range;
    private float rangeToWorldMult = 1;

    private LinkedList<GameObject> magnetizedObjects = new LinkedList<GameObject>();

    public float Range
    {
        get { return range;  }
        set
        {
            range = value;
            ResizeRadius();
        }
    }

    public void Demagnetize()
    {
        CleanUpList();
        foreach(GameObject obj in magnetizedObjects) {
            Magnetized magnetized = obj.GetComponent<Magnetized>();
            magnetized.magnet = null;
        }
    }

    void Update()
    {
        CleanUpList();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
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

            magnetizedObjects.AddLast(collider.gameObject);
        }
    }

    protected void ResizeRadius()
    {
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        collider.radius = range * rangeToWorldMult;
    }

    protected void CleanUpList()
    {
        var node = magnetizedObjects.First;
        while (node != null)
        {
            var next = node.Next;
            if (node.Value == null)
            {
                magnetizedObjects.Remove(node);
            }

            node = next;
        }
    }
}
