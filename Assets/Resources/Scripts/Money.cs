using UnityEngine;
using System.Collections;

public class Money : LevelObject {
    public int value;

    public void Collect()
    {
        Destroy(gameObject); //temporary
    }
}
