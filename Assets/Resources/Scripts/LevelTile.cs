using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTile : MonoBehaviour {

    public float xMin, xMax, yMin, yMax;
    public int objectsPerTile = 1;

    public LevelObject[] skyObjectPrefabs;
    public LevelObject[] groundObjectPrefabs;

    private List<LevelObject> children;


    // Use this for initialization
    void Start () {
        children = new List<LevelObject>(objectsPerTile);
        for (int i = 0; i < objectsPerTile; i++)
        {
            int randomObjectType = Random.Range(0, skyObjectPrefabs.Length);
            LevelObject objectToCreate = skyObjectPrefabs[randomObjectType];

            float randomLocX = Random.Range(xMin, xMax);
            float randomLocY = Random.Range(yMin, yMax);
            Vector3 objPos = new Vector3(randomLocX, randomLocY, 0f);

            children.Add((LevelObject)Instantiate(objectToCreate, objPos, transform.rotation));
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
