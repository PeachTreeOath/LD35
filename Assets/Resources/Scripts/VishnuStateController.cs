using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;
using System;

//Use this for checking/transitioning vishnu's avatar
public class VishnuStateController : MonoBehaviour
{

	//Singleton accessor for this obj. I think this will work...
	public static VishnuStateController instance { get { return m_instance; } }

	[SerializeField]
	public enum Avatar
	{
		NONE,
		MATSYA,
		KURMA,
		VARAHA,
		NARASIMHA,
		VAMANA,
		PARASHURAMA,
		RAMA,
		KRISHNA,
		BUDDHA,
		KALKI}

	;

	public enum State
	{
		PRE_FLIGHT,
		FLIGHT,
		NONE}

	;

	private State state = State.NONE;
	private bool pendingUpdate = false;

	[SerializeField]
	private AbilityData abilityDataRef;
	//source to load abilites from
	private Dictionary<Avatar, AvatarAbilityEntry> abilityEntries = new Dictionary<Avatar, AvatarAbilityEntry> ();
	private Dictionary<Avatar, Sprite> avatarSprites = new Dictionary<Avatar, Sprite> ();
	private Dictionary<Avatar, Sprite> avatarIconSprites = new Dictionary<Avatar, Sprite> ();

	private Dictionary<Avatar, AvatarInstance> avatarInstances = new Dictionary<Avatar, AvatarInstance> ();
	private AvatarInstance noneAvatarInstance = null;

	private static VishnuStateController m_instance;
	private int curAvatarIndex;
	private int nextAvatarIndex;
	//target of transition

	//slots -- used for positioning spheres
	[SerializeField]
	private int maxSlots = 5;
	//game level constant

	private int curNumSlotsOpen = 2;
	private List<Avatar> avatarSlot = new List<Avatar> ();
	//0-based index for each slot.

	void Awake ()
	{
		if (m_instance == null) {
			m_instance = this;
			DontDestroyOnLoad (gameObject);
			LoadAbilityData ();
			LoadSprites ();
		} else if (m_instance != null && m_instance != this) {
			Debug.Log ("Deleting singleton Dup.  Someone screwed up");
			Destroy (gameObject);
			return;
		}
	}

	private void LoadAbilityData ()
	{
		if (abilityDataRef == null) {
			Debug.LogError ("No ability data specified!");
			return;
		}

		abilityEntries.Clear ();
		foreach (AvatarAbilityEntry ent in abilityDataRef.getAll()) {
			abilityEntries [ent.avatar] = ent; 
		}
		Debug.Log ("Abilities loaded!");
	}

	private void LoadSprites ()
	{
		avatarSprites.Clear ();
		foreach (Avatar avatar in Enum.GetValues(typeof(Avatar))) {
			string textureName = GetSpriteTextureName (avatar);
			avatarSprites [avatar] = Resources.Load<Sprite> (textureName);

			textureName = GetIconTextureName (avatar);
			avatarIconSprites [avatar] = Resources.Load<Sprite> (textureName);
		}
	}

	public AvatarInstance getAvatarInstanceForSlot (int slot)
	{
		if (state == State.NONE || slot < 0 || slot >= avatarSlot.Count)
			return null;

		Avatar avatar = avatarSlot [slot];
		return getAvatarInstance (avatar);
	}

	public AvatarInstance getCurrentAvatarInstance ()
	{
		Avatar currentAvatar = getCurrentAvatar ();
		return getAvatarInstance (currentAvatar);
	}

	public AvatarInstance getAvatarInstance (Avatar avatar)
	{
		if (avatar == Avatar.NONE) {
			if (noneAvatarInstance == null)
				UpdateNoneAvatarInstance ();
			return noneAvatarInstance;
		}

		AvatarInstance avatarInstance = avatarInstances [avatar];
		if (!avatarInstance.IsAvailable)
			return getAvatarInstance (Avatar.NONE);
		else
			return avatarInstance;
	}

	public void UpdateNoneAvatarInstance ()
	{
		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();

		int levelOfNone = Mathf.RoundToInt ((float)inventory.GetTotalAvatarInventory () / 9f); //average level of "standard" avatars
		noneAvatarInstance = new AvatarInstance (abilityEntries [Avatar.NONE], levelOfNone);
	}

	public void PreFlight ()
	{
		if (state != State.NONE) {
			Debug.LogError ("Attempting to start a flight without ending the previous flight!");
			return;
		}

		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();

		updateAvatars (inventory.GetAvatarsInInventory ());

		avatarInstances.Clear ();
		foreach (Avatar avatar in avatarSlot) {
			int level = inventory.GetAvatarInventory (avatar); 
			avatarInstances [avatar] = new AvatarInstance (abilityEntries [avatar], level);
		}
		TransitionToNextAvatar (0);

		state = State.PRE_FLIGHT;
	}

	public void StartFlight ()
	{
		if (state != State.PRE_FLIGHT) {
			Debug.LogError ("Attempting to start a flight without runing PreFlight()!");
			return;
		}

		if (pendingUpdate) {
			doPlayerUpdate ();
			pendingUpdate = false;
		}
        

		state = State.FLIGHT;
	}

	public void StopFlight ()
	{
		if (state != State.FLIGHT) {
			Debug.LogError ("Attempting to end a flight without running StartFlight()!");
			return;
		}

		state = State.NONE;
	}

	// Update is called once per frame
	void Update ()
	{
		if (state != State.PRE_FLIGHT) {
			AvatarInstance avatarInstance = getCurrentAvatarInstance ();
			avatarInstance.Update ();

			if (!avatarInstance.IsAvailable && GameController.instance.getPlayerObj () != null && avatarInstance.avatar != Avatar.NONE) { // TODO: This is a temp fix for GameObject null ref.
				doPlayerUpdate (); //TODO this is janky way of triggering an Avatar=NONE pass
			}
		}
	}

	public int getNumSlotsOpen ()
	{
		return curNumSlotsOpen;
	}

	//Inserts (overwrites) all avatar slots with the passed in list, in the same order (call this after sphere slots are updated, for example)
	//Also sets the number of open slots equal to the size of the passed in list (so this will expand to more slots)
	//Also resets the curAvatarIndex to 0 (first in the given list)
	public void updateAvatars (List<Avatar> orderedAvatars)
	{
		avatarSlot.Clear ();
		avatarSlot.AddRange (orderedAvatars);
		curAvatarIndex = 0;
	}

	public Avatar getCurrentAvatar ()
	{
		return avatarSlot [curAvatarIndex];
	}

	//Using a numerical index, start a transition from the current index to the next
	public void TransitionToNextAvatar (int nextIndex)
	{
		curAvatarIndex = nextIndex; //TODO factor in time

		if (state == State.FLIGHT) {
			doPlayerUpdate ();
			Debug.Log ("Avatar transition complete");
		} else {
			Debug.Log ("Avatar transition deferred");
			pendingUpdate = true;
		}
	}

	private void doPlayerUpdate ()
	{
		AvatarInstance avatarInstance = getCurrentAvatarInstance ();
		changePlayerAttributes (avatarInstance.abilities);
		changePlayerSprite (avatarInstance.avatar);
	}

	//Set the given abilites to apply to the active player
	//TODO this is a prototype, we may want to make this more sophisticated by lerping and adding in time considerations etc
	public void changePlayerAttributes (Ability a)
	{

		GameObject player = GameController.instance.getPlayerObj ();

		//this is only a prototype of how this should work....improvements welcome
		Rigidbody2D rb = player.GetComponent<Rigidbody2D> ();
		//optionally we could turn these lift or dive forces into a one-time impulse force by using AddForce
		float gForce = (float)(1.0 - (a.liftForce * a.liftForceMult)) + (a.diveForce * a.diveForceMult);
		if (gForce < 0) {
			Debug.Log ("Negative gravity detected!");
		}
		rb.gravityScale = gForce;
		rb.mass = a.mass * a.liftForceMult;
		rb.drag = a.drag * a.dragMult;

		player.GetComponentInChildren<Magnet> ().Range = a.magnetRange;
	}

	public void changePlayerSprite (Avatar avatar)
	{
		GameObject player = GameController.instance.getPlayerObj ();
		SpriteRenderer sr = player.GetComponent<SpriteRenderer> ();

		sr.sprite = avatarSprites [avatar];

		if (avatar == Avatar.NONE)
			sr.color = new Color (1, 1, 1, 0.66f);
		else
			sr.color = Color.white;
	}

	public string GetSpriteTextureName (Avatar avatar)
	{
		switch (avatar) {
		case Avatar.BUDDHA:
			return "Textures/Buddha";
		case Avatar.RAMA:
			return "Textures/Rama";
		case Avatar.PARASHURAMA:
			return "Textures/VishnuAxe";
		case Avatar.MATSYA:
			return "Textures/VishnuFish";
		case Avatar.KURMA:
			return "Textures/VishnuTurtle";
		case Avatar.VARAHA:
			return "Textures/Boar";
		case Avatar.VAMANA:
			return "Textures/Vamana";
		case Avatar.KRISHNA:
			return "Textures/Krishna";
		case Avatar.NARASIMHA:
			return "Textures/Narasimha";
		case Avatar.NONE:
			return "Textures/SadSadVishnu";

		default:
			return "Textures/Vishnu";
		}
	}

	public string GetIconTextureName (Avatar avatar)
	{
		return GetSpriteTextureName (avatar) + "Icon";
	}

	///garbage garbage garbage...
	public Sprite GetIconSprite (Avatar avatar)
	{
		return avatarIconSprites [avatar];
	}


	public float GetLaunchPower ()
	{
		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();
		float total = 0;
		foreach (Avatar avatar in avatarSlot) {
			int level = inventory.GetAvatarInventory (avatar); 
			total += abilityEntries [avatar].GetAbilityAtLevel (level).launchForce;
		}
		return total;
	}

	public float GetBounciness ()
	{
		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();
		float total = 0;
		foreach (Avatar avatar in avatarSlot) {
			int level = inventory.GetAvatarInventory (avatar); 
			total += abilityEntries [avatar].GetAbilityAtLevel (level).bounciness;
		}
		return total;
	}

	public float GetDrag ()
	{
		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();
		float total = 0;
		foreach (Avatar avatar in avatarSlot) {
			int level = inventory.GetAvatarInventory (avatar); 
			total += abilityEntries [avatar].GetAbilityAtLevel (level).drag;
		}
		return total;
	}

	public float GetMass ()
	{
		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();
		float total = 0;
		foreach (Avatar avatar in avatarSlot) {
			int level = inventory.GetAvatarInventory (avatar); 
			total += abilityEntries [avatar].GetAbilityAtLevel (level).mass;
		}
		return total;
	}

	public float GetMoneyGain ()
	{
		Inventory inventory = GameObject.Find ("Singletons").GetComponent<Inventory> ();
		float total = 0;
		foreach (Avatar avatar in avatarSlot) {
			int level = inventory.GetAvatarInventory (avatar);
			total += abilityEntries [avatar].GetAbilityAtLevel (level).moneyGain;
		}
		return total;
	}
}
