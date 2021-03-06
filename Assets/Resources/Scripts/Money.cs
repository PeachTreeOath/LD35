﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Money : LevelObject
    {
    private int value;
	public RupeeColor color; 

	public enum RupeeColor{unknown, green, blue, yellow, red, purple, orange, silver};
	List<int> RupeeValues = new List<int>{ 0, 1, 5, 10, 20, 50, 100, 200 }; 

	public void Start(){

		SpriteRenderer sr = this.GetComponent<SpriteRenderer> ();
		sr.sprite = Resources.Load<Sprite>("Textures/rupeebw"); 

		if (color == RupeeColor.unknown) {
			int randColor = Random.Range (0, 100); 

			if (randColor >= 0 && randColor < 40) {
				color = RupeeColor.green;
			} else if (randColor >= 40 && randColor < 60) {
				color = RupeeColor.blue; 
			} else if (randColor >= 60 && randColor < 75) {
				color = RupeeColor.yellow; 
			} else if (randColor >= 75 && randColor < 88) {
				color = RupeeColor.red;
			} else if (randColor >= 88 && randColor < 93) {
				color = RupeeColor.purple;
			} else if (randColor >= 93 && randColor < 97) {
				color = RupeeColor.orange;
			} else {
				color = RupeeColor.silver; 
			}
		}

		switch (color) {
	
		case RupeeColor.green:
			value = RupeeValues [(int)RupeeColor.green]; 
			sr.material.SetColor ("_Color", Color.green);
			break; 
		case RupeeColor.blue:
			value = RupeeValues [(int)RupeeColor.blue]; 
			sr.material.SetColor ("_Color", Color.blue);
			break;
		case RupeeColor.yellow:
			value = RupeeValues [(int)RupeeColor.yellow]; 
			sr.material.SetColor ("_Color", Color.yellow);
			break; 
		case RupeeColor.red:
			value = RupeeValues [(int)RupeeColor.red]; 
			sr.material.SetColor ("_Color", Color.red);
			break; 
		case RupeeColor.purple:
			value = RupeeValues [(int)RupeeColor.purple]; 
			sr.material.SetColor ("_Color", Color.magenta);
			break; 
		case RupeeColor.orange: 
			value = RupeeValues [(int)RupeeColor.orange]; 
			sr.material.SetColor ("_Color", new Color(1f,.6f,0f,1f));
			break; 
		case RupeeColor.silver:
			value = RupeeValues [(int)RupeeColor.silver]; 
			sr.material.SetColor ("_Color", Color.gray);
			break; 
		}
	}

	public void Collect()
    {
        Destroy(gameObject); //temporary
    }

	public int GetValue(){
		return value;
	}
}
