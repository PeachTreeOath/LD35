using UnityEngine;
using System.Collections;

public class Hardness : MonoBehaviour {

    private bool isHard = false;
	
    public float Value
    {
        get { return isHard ? 1f : 0; }
        set { isHard = value > 0f; }
    }

    bool OnObstacleEnter(Collider2D collider) {
        return isHard;
    }
}
