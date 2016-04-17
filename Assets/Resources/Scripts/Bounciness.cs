using UnityEngine;
using System.Collections;

public class Bounciness : MonoBehaviour
{

	private BoxCollider2D platform;
	public float initialBounciness = 0.4f;
	private float bounciness = 0;
	public float newBounciness;
	private float statToPhysicsMult = 1;
	private bool disableBounce;

	public float Value {
		get { return bounciness; }
		set {
			bounciness = value;
			UpdateBounciness ();
		}
	}

	public bool NoBounce {
		get { return disableBounce; }
		set {
			bool prevValue = disableBounce;
			disableBounce = value;

			if (prevValue != disableBounce) {
				UpdateBounciness ();
			}
		}
	}

	void Start ()
	{
		//  UpdateInitialBounciness();
		platform = GameObject.Find ("GroundPlatform").GetComponent<BoxCollider2D> ();
	}

	void UpdateBounciness ()
	{
		if (platform == null) {
			platform = GameObject.Find ("GroundPlatform").GetComponent<BoxCollider2D> ();
		}
		bounciness = Mathf.Clamp (bounciness, 0, .55f); // Cap normal bounce at .95f
		PhysicsMaterial2D newGroundMaterial = new PhysicsMaterial2D ();
		newBounciness = initialBounciness + bounciness * statToPhysicsMult;
		newBounciness = NoBounce ? 0f : newBounciness;
		newGroundMaterial.bounciness = newBounciness;
		platform.sharedMaterial = newGroundMaterial;
	}
}
