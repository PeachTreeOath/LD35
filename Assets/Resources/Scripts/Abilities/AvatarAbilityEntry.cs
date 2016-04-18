using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class AvatarAbilityEntry {

    public VishnuStateController.Avatar avatar { get; private set; }
    private List<Ability> abilities = new List<Ability>();

    public static AvatarAbilityEntry For(VishnuStateController.Avatar avatar) {
        AvatarAbilityEntry entry = new AvatarAbilityEntry();
        entry.avatar = avatar;
        return entry;
    }

    public int GetMaxAbilityLevel()
    {
        abilities.Sort((lhs, rhs) => lhs.level - rhs.level);
        return abilities[abilities.Count - 1].level;
    }

    public Ability GetAbilityAtLevel(int level)
    {
        abilities.Sort((lhs, rhs) => lhs.level - rhs.level );

        int minlevel = abilities[0].level;
        int maxLevel = abilities[abilities.Count - 1].level;

        level = Math.Min(maxLevel, level);
        level = Math.Max(minlevel, level);

        if (level == minlevel) return abilities[0];
        if (level == maxLevel) return abilities[abilities.Count - 1];

        for(int i = 0; i < abilities.Count; i++)
        {
            Ability next = abilities[i];
            if(next.level >= level)
            {
                Ability prev = abilities[i - 1];
                return Ability.LerpAbilities(prev, next, level);
            }
        }

        Debug.LogError("Defaulting to MAX stats");
        return abilities[abilities.Count - 1];
    }

    public AvatarAbilityEntry Set(Ability ability)
    {
        abilities.Add(ability);
        return this;
    }
}