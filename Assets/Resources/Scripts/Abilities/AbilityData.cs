using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//This contains the hardcoded ability data for each avatar
//Ideally this would be modifyable through the inspector, but I don't have time to implement that
[Serializable]
public class AbilityData
{

	[SerializeField]
	public List<AvatarAbilityEntry> ents = new List<AvatarAbilityEntry> ();

	AbilityData ()
	{
		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.NONE)
               .Set (Ability.AtLevel (1))
               .Set (Ability.AtLevel (10))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.MATSYA)
               .Set (Ability.AtLevel (1)
                    .Bounciness(1)
                    .Mass(1)
                    .Tastiness(1)
                    .Energy (100))
               .Set (Ability.AtLevel (10)
                    .Bounciness(10)
                    .Mass(10)
                    .Tastiness(10)
                    .Energy (1000))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.KURMA)
               .Set (Ability.AtLevel (1)
                    .Drag(1)
                    .Mass(1)
                    .Hardness(1)
                    .Energy (100))
               .Set (Ability.AtLevel (10)
                    .Drag(10)
                    .Mass(10)
                    .Hardness(10)
                    .Energy (1000))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.VARAHA)
               .Set (Ability.AtLevel (1)
                    .LaunchForce(1)
                    .Mass(1)
                    .Energy (100))
               .Set (Ability.AtLevel (10)
                    .LaunchForce(10)
                    .Mass(10)
                    .Energy (1000))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.NARASIMHA)
               .Set (Ability.AtLevel (1)
                    .Bounciness(1)
                    .MoneyGain(1)
                    .Energy (100))
               .Set (Ability.AtLevel (10)
                    .Bounciness(10)
                    .MoneyGain(10)
                    .Energy (1000))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.VAMANA)
               .Set (Ability.AtLevel (1)
                    .Bounciness(1)
                    .Drag(1)
                    .Umbrella(1)
                    .Energy (100))
               .Set (Ability.AtLevel (10)
                    .Bounciness(10)
                    .Drag(10)
                    .Umbrella(1)
                    .Energy (1000))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.PARASHURAMA)
               .Set (Ability.AtLevel (1)
                    .Energy (100)
                    .LaunchForce(1)
                    .Drag(1)
                    .DiveKick (1))
               .Set (Ability.AtLevel (10)
                    .Energy (1000)
                    .LaunchForce(10)
                    .Drag(10)
                    .DiveKick (1))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.RAMA)
               .Set (Ability.AtLevel (1)
                    .Energy (100)
                    .Mass(1)
				.MoneyGain(1).SuperJump(1))
               .Set (Ability.AtLevel (10)
                    .Energy (1000)
                    .Mass(10)
				.MoneyGain(10).SuperJump(1))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.KRISHNA)
               .Set (Ability.AtLevel (1)
                    .Energy (100)
                    .LaunchForce(1)
                    .Drag(1)
                    .MagnetRange (5f))
               .Set (Ability.AtLevel (10)
                    .Energy (1000)
                    .LaunchForce(10)
                    .Drag(10)
                    .MagnetRange (20f))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.BUDDHA)
               .Set (Ability.AtLevel (1)
                    .Energy (100)
                    .LaunchForce(1)
                    .Bounciness(1)
				    .BuddhaBounciness (1))
               .Set (Ability.AtLevel (10)
                    .Energy (1000)
                    .LaunchForce(10)
                    .Bounciness(10)
                    .BuddhaBounciness (10))
		);

		AddEntry (
			AvatarAbilityEntry.For (VishnuStateController.Avatar.KALKI)
               .Set (Ability.AtLevel (1)
                    .Energy (100))
               .Set (Ability.AtLevel (10)
                    .Energy (1000))
		);
	}

	public void AddEntry (AvatarAbilityEntry entry)
	{
		ents.Add (entry);
	}

	public List<AvatarAbilityEntry> getAll ()
	{
		return ents;
	}

}