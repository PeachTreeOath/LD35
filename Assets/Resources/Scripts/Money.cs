using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Money : MonoBehaviour {
    public int value;

	enum RupeeColor{green, blue, yellow, red, purple, orange, silver};
	List<int> RupeeValues = new List<int>{ 1, 5, 10, 20, 50, 100, 200 }; 

	public void Start(){

		SpriteRenderer sr = this.GetComponent<SpriteRenderer> ();
		sr.sprite = Resources.Load<Sprite>("Textures/rupeebw"); 

		int randColor = Random.Range (0, 100); 
		if (randColor >= 0 && randColor < 30) {
			value = RupeeValues [(int)RupeeColor.green]; 
			sr.material.SetColor ("_Color", Color.green);
		} else if (randColor >= 30 && randColor < 50) {
			value = RupeeValues [(int)RupeeColor.blue]; 
			sr.material.SetColor ("_Color", Color.blue);
		} else if (randColor >= 50 && randColor < 65) {
			value = RupeeValues [(int)RupeeColor.yellow]; 
			sr.material.SetColor ("_Color", Color.yellow);
		} else if (randColor >= 65 && randColor < 75) {
			value = RupeeValues [(int)RupeeColor.red]; 
			sr.material.SetColor ("_Color", Color.red);
		} else if (randColor >= 75 && randColor < 85) {
			value = RupeeValues [(int)RupeeColor.purple]; 
			sr.material.SetColor ("_Color", Color.magenta);
		} else if (randColor >= 85 && randColor < 95) {
			value = RupeeValues [(int)RupeeColor.orange]; 
			sr.material.SetColor ("_Color", new Color(255f,165f,0f,1f));
		} else {
			value = RupeeValues [(int)RupeeColor.silver]; 
			sr.material.SetColor ("_Color", Color.gray);
		}

		Debug.Log ("value =" + value); 
	}

	public void Collect()
    {
        Destroy(gameObject); //temporary
    }
}
