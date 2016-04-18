using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
	public GameObject playerPrefab;
    public float powerMultiplier = .00001f;
    
	// Use this for initialization
	void Start ()
	{
        //Debug.Log("Start:powerMult: " + powerMult);
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Debug.Log("Update:powerMult: " + powerMult);
    }

    public void LaunchPlayer(float angle, float power)
    {
        GameObject obj = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Player player = obj.GetComponent<Player>();

        player.Init();
        player.Fire(Mathf.Deg2Rad * angle, power * powerMultiplier);
    }
}
