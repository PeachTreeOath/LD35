using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Ability {

    public int level;
    public float cost;

    public float energy;
    public float drainRate;

    //base ability values
    public float launchForce;
    public float mass = 1;
    public float drag = 0.5f;
    public float liftForce;
    public float bounciness;
    public float jumpForce;
    public float magnetoForce;
    public float diveForce;

    //ability mods
    public float jumpForceMult = 1;
    public float diveForceMult = 1;
    public float liftForceMult = 1;
    public float dragMult = 1;

    public static Ability AtLevel(int level)
    {
        Ability ability = new Ability();
        ability.level = level;

        return ability;
    }

    public Ability Energy(float value) { energy = value;  return this;  }
    public Ability DrainRate(float value) { drainRate = value;  return this;  }
    public Ability Cost(float value) { cost = value; return this; }
    public Ability LaunchForce(float value) { launchForce = value;  return this; }
    public Ability Mass(float value) { mass = value; return this; }
    public Ability Drag(float value) { drag = value; return this; }
    public Ability LiftForce(float value) { liftForce = value; return this; }
    public Ability Bounciness(float value) { bounciness = value; return this; }
    public Ability JumpForce(float value) { jumpForce = value; return this; }
    public Ability DiveForce(float value) { diveForce = value; return this; }

    public static Ability LerpAbilities(Ability min, Ability max, int level)
    {
        float t = level / (float)(max.level - min.level);

        Ability ability = new Ability();
        ability.level = level;
        ability.energy = Mathf.Lerp(min.energy, max.energy, t);
        ability.drainRate = Mathf.Lerp(min.drainRate, max.drainRate, t);
        ability.cost = Mathf.Lerp(min.cost, max.cost, t);
        ability.launchForce = Mathf.Lerp(min.launchForce, max.launchForce, t);
        ability.mass = Mathf.Lerp(min.mass, max.mass, t);
        ability.drag = Mathf.Lerp(min.drag, max.drag, t);
        ability.liftForce = Mathf.Lerp(min.liftForce, max.liftForce, t);
        ability.bounciness = Mathf.Lerp(min.bounciness, max.bounciness, t);
        ability.jumpForce = Mathf.Lerp(min.jumpForce, max.jumpForce, t);
        ability.diveForce = Mathf.Lerp(min.diveForce, max.diveForce, t);

        return ability;
    }
}
