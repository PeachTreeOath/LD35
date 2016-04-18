using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Ability {

    public int level;
    public float cost;

    public float energy;
    public float drainRate = 25;

    //base ability values
    public float launchForce;
    public float mass = 1;
    public float drag = 0.5f;

    public float liftForce;
    public float bounciness;
	public float buddhaBounciness;
    public float moneyGain;
    public float jumpForce;
    public float diveForce;

    //ability mods
    public float jumpForceMult = 1;
    public float diveForceMult = 1;
    public float liftForceMult = 1;
    public float dragMult = .5f;

    public float magnetRange = 2.5f; // Krishna (flute boy)
    public float diveKick; // Parashurama (axe man)
    public float hardness; // Kurma (turtle)
    public float metabolism; // Lion
    public float umbrella; // Vamana
	public float superJump; // Rama
    public float tastiness; // Matsya (fish)
    public float boar; // Varaha

    public static Ability AtLevel(int level)
    {
        Ability ability = new Ability();
        ability.level = level;

        return ability;
    }

    public Ability Energy(float value) { energy = value;  return this;  }
    public Ability DrainRate(float value) { drainRate = value;  return this;  }
    public Ability Cost(float value) { cost = value; return this; }
    public Ability LaunchForce(float value) { launchForce = value;  return this; }
    public Ability Mass(float value) { mass = value; return this; }
    public Ability Drag(float value) { drag = value; return this; }
    public Ability LiftForce(float value) { liftForce = value; return this; }
    public Ability Bounciness(float value) { bounciness = value; return this; }
	public Ability BuddhaBounciness(float value) { buddhaBounciness = value; return this; }
    public Ability MoneyGain(float value) { moneyGain = value;  return this; }
    public Ability JumpForce(float value) { jumpForce = value; return this; }
    public Ability DiveForce(float value) { diveForce = value; return this; }
    public Ability MagnetRange(float value) { magnetRange = value;  return this; }
    public Ability DiveKick(float value) { diveKick = value;  return this;  }
    public Ability Hardness(float value) { hardness = value;  return this;  }
    public Ability Metabolism(float value) { metabolism = value;  return this;  }
    public Ability Umbrella(float value) { umbrella = value; return this; }
	public Ability SuperJump(float value) { superJump = value;  return this;  }
    public Ability Tastiness(float value) { tastiness = value; return this; }
    public Ability Boar(float value) { boar = value; return this; }

    public static Ability LerpAbilities(Ability min, Ability max, int level)
    {
        float t = level / (float)(max.level - min.level);

        Ability ability = new Ability();
        ability.level = level;
        ability.energy = Mathf.Lerp(min.energy, max.energy, t);
        ability.drainRate = Mathf.Lerp(min.drainRate, max.drainRate, t);
        ability.cost = Mathf.Lerp(min.cost, max.cost, t);
        ability.launchForce = Mathf.Lerp(min.launchForce, max.launchForce, t);
        ability.mass = Mathf.Lerp(min.mass, max.mass, t);
        ability.drag = Mathf.Lerp(min.drag, max.drag, t);
        ability.liftForce = Mathf.Lerp(min.liftForce, max.liftForce, t);
        ability.bounciness = Mathf.Lerp(min.bounciness, max.bounciness, t);
		ability.buddhaBounciness = Mathf.Lerp(min.buddhaBounciness, max.bounciness, t);
        ability.jumpForce = Mathf.Lerp(min.jumpForce, max.jumpForce, t);
        ability.diveForce = Mathf.Lerp(min.diveForce, max.diveForce, t);
        ability.magnetRange = Mathf.Lerp(min.magnetRange, max.magnetRange, t);
        ability.moneyGain = Mathf.Lerp(min.moneyGain, max.moneyGain, t);
        ability.diveKick = Mathf.Lerp(min.diveKick, max.diveKick, t);
        ability.hardness = Mathf.Lerp(min.hardness, max.hardness, t);
        ability.metabolism = Mathf.Lerp(min.metabolism, max.metabolism, t);
        ability.umbrella = Mathf.Lerp(min.umbrella, max.umbrella, t);
		ability.superJump = Mathf.Lerp(min.superJump, max.superJump, t);
        ability.tastiness = Mathf.Lerp(min.tastiness, max.tastiness, t);
        ability.boar = Mathf.Lerp(min.boar, max.boar, t);

        return ability;
    }
}
