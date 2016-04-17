using UnityEngine;
using System.Collections;

public class Bounciness : MonoBehaviour {

    public PhysicsMaterial2D groundMaterial;

    private float? initialBounciness = null;

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

    void Start() {
        UpdateInitialBounciness();
    }

	void UpdateBounciness() {
        UpdateInitialBounciness();
        groundMaterial.bounciness = (float)initialBounciness + bounciness * statToPhysicsMult;
    }

    void UpdateInitialBounciness()
    {
        if (initialBounciness == null)
            initialBounciness = groundMaterial.bounciness;
    }
}
