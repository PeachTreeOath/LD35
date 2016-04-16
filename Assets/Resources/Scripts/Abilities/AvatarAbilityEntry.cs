using UnityEngine;
using UnityEditor;
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

        if (level == maxLevel) return abilities[abilities.Count - 1];

        for(int i = 0; i < abilities.Count; i++)
        {
            Ability next = abilities[i];
            if(next.level >= level)
            {
                Ability prev = abilities[i - 1];
                return LerpAbilities(prev, next, level);
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

    private Ability LerpAbilities(Ability min, Ability max, int level)
    {
        float t = level / (float)(max.level - min.level);

        Ability ability = new Ability();
        ability.level = level;
        ability.energy = Mathf.Lerp(min.energy, max.energy, t);
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