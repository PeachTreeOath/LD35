using UnityEngine;
using System.Collections;

public class ObstacleVector : LevelObject {
    public Vector2 velocityChange;

	public enum VectorObstacles {unknown, balloon, lotus}; 
	public VectorObstacles obstacleType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Remove()
    {
        Destroy(gameObject); //temporary
    }


}
