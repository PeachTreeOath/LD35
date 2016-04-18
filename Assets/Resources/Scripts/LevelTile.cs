using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTile : MonoBehaviour {

    public float xMin, xMax, yMin, yMax;
    public int objectsPerTile = 100;
    public float levelTriggerOffset = 20; //needs to not be 0 so we don't erase the tile while the player can still see it.

    public LevelObject[] skyObjectPrefabs;
    public LevelObject[] groundObjectPrefabs;

    public LevelGenTrigger levelGenTriggerPrefab;

    private List<LevelObject> children;
    private LevelGenTrigger levelGenTrigger;
    private bool startInUpdate = false; //for updating properties outside of Start
    public bool isATile = false;

	private int skyToGroundRatio = 10;


    // Use this for initialization
    void Start () {

		Debug.Log ("Start");
        children = new List<LevelObject>(objectsPerTile);
        for (int i = 0; i < objectsPerTile; i++)
        {
			int randomObjectType = Random.Range(0, skyObjectPrefabs.Length*skyToGroundRatio + groundObjectPrefabs.Length);
			LevelObject objectToCreate;
			float randomLocY;

			if (randomObjectType < skyObjectPrefabs.Length*skyToGroundRatio) {
				objectToCreate = skyObjectPrefabs [randomObjectType/skyToGroundRatio];
				randomLocY = Random.Range(yMin, yMax);
			}else{
				objectToCreate = groundObjectPrefabs [randomObjectType - skyObjectPrefabs.Length*skyToGroundRatio];
				randomLocY = -4.5f;
			}

            float randomLocX = Random.Range(xMin, xMax);
           // float randomLocY = Random.Range(yMin, yMax);
            Vector3 objPos = new Vector3(randomLocX, randomLocY, 0f);

            children.Add((LevelObject)Instantiate(objectToCreate, objPos, transform.rotation));
            children[i].transform.SetParent(transform, true);
        }

        Vector3 newPos = new Vector3(transform.position.x + levelTriggerOffset, transform.position.y);
        levelGenTrigger = (LevelGenTrigger)Instantiate(levelGenTriggerPrefab, newPos, transform.rotation);
        levelGenTrigger.transform.SetParent(transform, true);
        children.Add(levelGenTrigger);

		startInUpdate = true; 

    }
    
	
	// Update is called once per frame
	void Update () {
        if (startInUpdate)
        {
            levelGenTrigger.isATrigger = isATile;
            startInUpdate = false;
        }
	
	}

    public float getWidth()
    {
        return xMax - xMin;
    }

    public void remove()
    {
        Destroy(gameObject);
    }


}
