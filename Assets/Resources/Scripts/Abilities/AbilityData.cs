using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//This contains the hardcoded ability data for each avatar
//Ideally this would be modifyable through the inspector, but I don't have time to implement that
[Serializable]
public class AbilityData {

    [SerializeField]
    public List<AvatarAbilityEntry> ents = new List<AvatarAbilityEntry>();

    AbilityData() {
        AddEntry(
           AvatarAbilityEntry.For(VishnuStateController.Avatar.NONE)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
       );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.MATSYA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.KURMA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.VARAHA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.NARASIMHA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))    
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.VAMANA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.PARASHURAMA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.RAMA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.KRISHNA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );

        AddEntry(
           AvatarAbilityEntry.For(VishnuStateController.Avatar.BUDDHA)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
       );

        AddEntry(
            AvatarAbilityEntry.For(VishnuStateController.Avatar.KALKI)
               .Set(Ability.AtLevel(1))
               .Set(Ability.AtLevel(10))
        );
    }

    public void AddEntry(AvatarAbilityEntry entry) { ents.Add(entry);  }

    public List<AvatarAbilityEntry> getAll() {
        return ents;
    }

}