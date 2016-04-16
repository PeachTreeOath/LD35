using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Ability {

    public int level;
    public float cost;
    public float energy;

    //base ability values
    public float launchForce;
    public float mass;
    public float drag;
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
    public Ability Cost(float value) { cost = value; return this; }
    public Ability LaunchForce(float value) { launchForce = value;  return this; }
    public Ability Mass(float value) { mass = value; return this; }
    public Ability Drag(float value) { drag = value; return this; }
    public Ability LiftForce(float value) { liftForce = value; return this; }
    public Ability Bounciness(float value) { bounciness = value; return this; }
    public Ability JumpForce(float value) { jumpForce = value; return this; }
    public Ability DiveForce(float value) { diveForce = value; return this; }
}
