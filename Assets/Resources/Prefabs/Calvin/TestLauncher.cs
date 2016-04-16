using UnityEngine;
using System.Collections;

public class TestLauncher : MonoBehaviour
{
	public float force;
	public GameObject playerPrefab;
	private bool isShot;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && !isShot) {
			GameObject obj = (GameObject)Instantiate (playerPrefab, transform.position, Quaternion.identity);
			Player player = obj.GetComponent<Player> ();
			player.Init ();
			player.Fire (transform.rotation.eulerAngles.z, force);

			isShot = true;
		}
	}
}
