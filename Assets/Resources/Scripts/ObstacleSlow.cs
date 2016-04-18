using UnityEngine;
using System.Collections;

public class ObstacleSlow : LevelObject {

    public float reduction = 0;
    public float speedLimit = float.MaxValue;

    public override void Remove() {
        Destroy(gameObject);
    }
}
