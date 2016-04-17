using UnityEngine;
using System.Collections;

public class Bounciness : MonoBehaviour
{

	private BoxCollider2D platform;
	public float initialBounciness = 0.5f;
	private float bounciness = 0;
	public float newBounciness;
	private float statToPhysicsMult = 1;

	public float Value {
		get { return bounciness; }
		set {
			bounciness = value;
			UpdateBounciness ();
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

		PhysicsMaterial2D newGroundMaterial = new PhysicsMaterial2D ();
		newBounciness = initialBounciness + bounciness * statToPhysicsMult;
		newGroundMaterial.bounciness = newBounciness;
		platform.sharedMaterial = newGroundMaterial;
	}

	/* void UpdateInitialBounciness()
    {
        if (initialBounciness == null)
            initialBounciness = groundMaterial.bounciness;
    }*/
}
