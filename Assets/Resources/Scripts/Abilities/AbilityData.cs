using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//This contains the hardcoded ability data for each avatar
//Ideally this would be modifyable through the inspector, but I don't have time to implement that
[Serializable]
public class AbilityData : ScriptableObject{

    [SerializeField]
    public List<AvatarAbilityEntry> ents;

    AbilityData() {
        ents = getAll();
        foreach(AvatarAbilityEntry e in ents) {
            CustomAssetUtility.AddObjToAsset(this, e);
        }
    }

    public List<AvatarAbilityEntry> getAll() {
        List<AvatarAbilityEntry> entries = new List<AvatarAbilityEntry>();

        Ability a;
        VishnuStateController.Avatar aType;

        ////
        aType = VishnuStateController.Avatar.MATSYA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.KURMA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.VARAHA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.NARASIMHA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.VAMANA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.PARASHURAMA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.RAMA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.KRISHNA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.BUDDHA;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.KALKI;
        a = ScriptableObject.CreateInstance<Ability>();
        a.launchForce = 0;
        a.mass = 0;
        a.drag = 0;
        a.liftForce = 0;
        a.bounciness = 0;
        a.jumpForce = 0;
        a.magnetoForce = 0;
        a.diveForce = 0;
        //ability mods
        a.launchForceMult = 0;
        a.massMult = 0;
        a.dragMult = 0;
        a.liftForceMult = 0;
        a.bouncinessMult = 0;
        a.jumpForceMult = 0;
        a.magnetoForceMult = 0;
        a.diveForceMult = 0;
        entries.Add(ScriptableObject.CreateInstance<AvatarAbilityEntry>().construct(aType, a));
        ///////


        return entries;
    }

}