using UnityEngine;
using System.Collections;

public class TestLauncher : MonoBehaviour
{
	public GameObject playerPrefab;
    
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    public void LaunchPlayer(float angle, float power)
    {
        GameObject obj = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Player player = obj.GetComponent<Player>();

        player.Init();
        player.Fire(Mathf.Deg2Rad * angle, power);
    }
}
