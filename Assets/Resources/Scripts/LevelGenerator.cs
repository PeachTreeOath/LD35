using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
    public LevelTile levelTilePrefab;
    //public LevelObject[] levelObjectPrefabs;

	public LevelTile genLevelTile()
    {
        LevelTile levelTile =  (LevelTile)Instantiate(levelTilePrefab, transform.position, transform.rotation);
        //LevelObject levelObject = (LevelObject)Instantiate(levelObjectPrefabs[0], transform.position, transform.rotation);
        

        return levelTile;
    }
}
