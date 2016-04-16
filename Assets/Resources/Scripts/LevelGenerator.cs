using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
    public LevelTile levelTilePrefab;

	public LevelTile genLevelTile()
    {
        LevelTile levelTile =  (LevelTile)Instantiate(levelTilePrefab, transform.position, Quaternion.identity);
        return levelTile;
    }
}
