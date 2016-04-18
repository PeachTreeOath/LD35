using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
	public GameObject playerPrefab;
    public float powerMult = .00001f;
    
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
        player.Fire(Mathf.Deg2Rad * angle, power * powerMult);
    }
}
