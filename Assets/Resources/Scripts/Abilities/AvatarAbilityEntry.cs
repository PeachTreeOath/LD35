using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
public class AvatarAbilityEntry : ScriptableObject {

    public VishnuStateController.Avatar avatar;
    public Ability abilities;

    public AvatarAbilityEntry() {
        //name = "AvatarAbility";
    }

    public AvatarAbilityEntry(VishnuStateController.Avatar avatar, Ability abilities) {
        this.avatar = avatar;
        this.abilities = abilities;
    }


    //This is not ready for primetime yet
    [MenuItem("Assets/Create/AvatarAbilityEntry")]
    public static void CreateAsset() {
        CustomAssetUtility.CreateAsset<AvatarAbilityEntry>();
    }
}