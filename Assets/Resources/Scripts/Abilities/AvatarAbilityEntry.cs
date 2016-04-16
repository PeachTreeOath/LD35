using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[Serializable]
public class AvatarAbilityEntry : ScriptableObject {

    [SerializeField]
    public VishnuStateController.Avatar avatar;
    [SerializeField]
    public Ability abilities;


    public AvatarAbilityEntry construct(VishnuStateController.Avatar avatar, Ability abilities) {
        this.avatar = avatar;
        this.abilities = abilities;
        return this;
    }

}