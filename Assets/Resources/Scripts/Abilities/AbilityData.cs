﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This contains the hardcoded ability data for each avatar
//Ideally this would be modifyable through the inspector, but I don't have time to implement that
public class AbilityData : ScriptableObject {

    public List<AvatarAbilityEntry> entries = new List<AvatarAbilityEntry>();

    public List<AvatarAbilityEntry> getAll() {
        Ability a;
        VishnuStateController.Avatar aType;

        ////
        aType = VishnuStateController.Avatar.MATSYA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.KURMA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.VARAHA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.NARASIMHA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.VAMANA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.PARASHURAMA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.RAMA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.KRISHNA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.BUDDHA;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////
        ////
        aType = VishnuStateController.Avatar.KALKI;
        a = new Ability();
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
        entries.Add(new AvatarAbilityEntry(aType, a));
        ///////


        return entries;
    }

}