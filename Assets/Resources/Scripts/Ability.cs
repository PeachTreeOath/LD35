using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Ability : ScriptableObject {

    //base ability values
    [SerializeField]
    public float launchForce;
    [SerializeField]
    public float mass;
    [SerializeField]
    public float drag;
    [SerializeField]
    public float liftForce;
    [SerializeField]
    public float bounciness;
    [SerializeField]
    public float jumpForce;
    [SerializeField]
    public float magnetoForce;
    [SerializeField]
    public float diveForce;

    //ability mods
    [SerializeField]
    public float launchForceMult;
    [SerializeField]
    public float massMult;
    [SerializeField]
    public float dragMult;
    [SerializeField]
    public float liftForceMult;
    [SerializeField]
    public float bouncinessMult;
    [SerializeField]
    public float jumpForceMult;
    [SerializeField]
    public float magnetoForceMult;
    [SerializeField]
    public float diveForceMult;


}
