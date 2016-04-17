using UnityEngine;
using System.Collections;

public class ObstacleScalar : LevelObject  {
    public float scalar;

    public void Remove()
    {
        Destroy(gameObject); //temporary
    }
}
