using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AvatarDescriptions : MonoBehaviour
{

	private Text text;

	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void ChangeAvatarText (VishnuStateController.Avatar av)
	{
		switch (av) {
		case VishnuStateController.Avatar.BUDDHA:
			text.text = "Current form - BUDDHA: Big bounce";
			break;
		case VishnuStateController.Avatar.RAMA:
			text.text = "Current form - RAMA: Jumps upward";
			break;
		case VishnuStateController.Avatar.PARASHURAMA:
			text.text = "Current form - PARASHURAMA: Dives down with attack";
			break;
		case VishnuStateController.Avatar.MATSYA:
			text.text = "Current form - MATSYA: Birds carry you";
			break;
		case VishnuStateController.Avatar.KURMA:
			text.text = "Current form - KURMA: Unaffected by obstacles";
			break;
		case VishnuStateController.Avatar.VARAHA:
			text.text = "Current form - VARAHA: Runs on the ground and jumps on avatar switch";
			break;
		case VishnuStateController.Avatar.VAMANA:
			text.text = "Current form - VAMANA: Floats with umbrella";
			break;
		case VishnuStateController.Avatar.KRISHNA:
			text.text = "Current form - KRISHNA: Magnetizes rupees";
			break;
		case VishnuStateController.Avatar.NARASIMHA:
			text.text = "Current form - NARASIMHA: Eats animals for power";
			break;
		case VishnuStateController.Avatar.KALKI:
			text.text = "Current form - KALKI: The FINAL FORM!";
			break;
		case VishnuStateController.Avatar.NONE:
			text.text = "Current form - NONE: Low bounce";
			break;
		default:
			text.text = "";
			break;
		}
	}
}
