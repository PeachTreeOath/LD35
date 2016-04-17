using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{

	public float scrollSpeed;
	private Vector2 savedOffset;
	private float totalDist;

	// Use this for initialization
	void Start ()
	{
		savedOffset = GetComponent<Renderer> ().material.GetTextureOffset ("_MainTex");
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Scroll(float dist)
	{
		totalDist += dist;
		float x = Mathf.Repeat (totalDist*scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, savedOffset.y);
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", offset);
	}
}
