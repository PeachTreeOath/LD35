using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
    public LevelTile levelTilePrefab;

    private bool startInUpdate = false;
    private LevelTile wipLevelTile;
    private bool isATile;

	public LevelTile genLevelTile(bool isATile)
    {
        wipLevelTile =  (LevelTile)Instantiate(levelTilePrefab, transform.position, transform.rotation);
        this.isATile = isATile;
        startInUpdate = true;
        return wipLevelTile;
    }

    void Update()
    {
        if (startInUpdate)
        {
            wipLevelTile.isATile = isATile;
        }
    }



    public float getTileWidth()
    {
        return levelTilePrefab.getWidth();
    }




}
