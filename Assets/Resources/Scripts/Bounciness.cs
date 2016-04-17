using UnityEngine;
using System.Collections;

public class Bounciness : MonoBehaviour {

    public PhysicsMaterial2D groundMaterial;
    public float initialBounciness = 0.8f;

    private bool disableBounce = false;
    private float bounciness = 0;
    private float statToPhysicsMult = 1;

    public float Value
    {
        get { return bounciness; }
        set
        {
            bounciness = value;
            UpdateBounciness();
        }
    }

    public bool NoBounce
    {
        get { return disableBounce;  }
        set
        {
            bool prevValue = disableBounce;
            disableBounce = value;

            if(prevValue != disableBounce) {
                UpdateBounciness();
            }
        }
    }

	void UpdateBounciness() {
        float value = initialBounciness + bounciness * statToPhysicsMult;
        groundMaterial.bounciness = NoBounce ? 0f : value;
    }
}
