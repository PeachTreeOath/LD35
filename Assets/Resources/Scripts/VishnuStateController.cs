using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Resources.Scripts;

//Use this for checking/transitioning vishnu's avatar
public class VishnuStateController : MonoBehaviour {

    //Singleton accessor for this obj. I think this will work...
    public static VishnuStateController instance { get { return m_instance; } }

    [SerializeField]
    public enum Avatar { NONE, MATSYA, KURMA, VARAHA, NARASIMHA, VAMANA, PARASHURAMA, RAMA, KRISHNA, BUDDHA, KALKI };
    public enum State { PRE_FLIGHT, FLIGHT, NONE };

    private State state = State.NONE;

    [SerializeField]
    private AbilityData abilityDataRef; //source to load abilites from
    private Dictionary<Avatar, AvatarAbilityEntry> abilityEntries = new Dictionary<Avatar, AvatarAbilityEntry>();

    private Dictionary<Avatar, AvatarInstance> avatarInstances = new Dictionary<Avatar, AvatarInstance>();
    private AvatarInstance noneAvatarInstance = null;

    private static VishnuStateController m_instance;
    private int curAvatarIndex;
    private int nextAvatarIndex; //target of transition

    //slots -- used for positioning spheres
    [SerializeField]
    private int maxSlots = 5; //game level constant

    private int curNumSlotsOpen = 2;
    private List<Avatar> avatarSlot = new List<Avatar>(); //0-based index for each slot.

    
    void SetInitialState()
    {
        List<Avatar> newSpheres = new List<Avatar>();
        newSpheres.Add(Avatar.BUDDHA);
        newSpheres.Add(Avatar.PARASHURAMA);

        updateAvatars(newSpheres);
    }

    void Awake() {
        if (m_instance == null) {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAbilityData();
            SetInitialState();
        }
        else if(m_instance != null && m_instance != this) {
            Debug.Log("Deleting singleton Dup.  Someone screwed up");
            Destroy(gameObject);
            return;
        }
    }

    private void LoadAbilityData() {
        if(abilityDataRef == null) {
            Debug.LogError("No ability data specified!");
            return;
        }

        foreach(AvatarAbilityEntry ent in abilityDataRef.getAll()){
            abilityEntries[ent.avatar] = ent; 
        }
        Debug.Log("Abilities loaded!");
    }

    public AvatarInstance getAvatarInstanceForSlot(int slot)
    {
        if (state == State.NONE || slot < 0 || slot >= avatarSlot.Count)
            return getAvatarInstance(Avatar.NONE);

        Avatar avatar = avatarSlot[slot];
        return getAvatarInstance(avatar);
    }

    public AvatarInstance getCurrentAvatarInstance()
    {
        Avatar currentAvatar = getCurrentAvatar();
        return getAvatarInstance(currentAvatar);
    }

    public AvatarInstance getAvatarInstance(Avatar avatar)
    {
        if(avatar == Avatar.NONE)
        {
            if (noneAvatarInstance == null) UpdateNoneAvatarInstance();
            return noneAvatarInstance;
        }

        AvatarInstance avatarInstance = avatarInstances[avatar];
        if (!avatarInstance.IsAvailable)
            return getAvatarInstance(Avatar.NONE);
        else
            return avatarInstance;
    }

    public void UpdateNoneAvatarInstance()
    {  
        int levelOfNone = 1; //TODO we could calculate some aggregate level of this, so it gets better as your stats go up
        noneAvatarInstance = new AvatarInstance(abilityEntries[Avatar.NONE], levelOfNone);
    }

    public void PreFlight()
    {
        if (state != State.NONE)
        {
            Debug.LogError("Attempting to start a flight without ending the previous flight!");
            return;
        }

        avatarInstances.Clear();
        foreach (Avatar avatar in avatarSlot)
        {
            int level = 1; //TODO get level of current inventory
            avatarInstances[avatar] = new AvatarInstance(abilityEntries[avatar], level);
        }

        state = State.PRE_FLIGHT;
    }

    public void StartFlight()
    {
        if(state != State.PRE_FLIGHT) {
            Debug.LogError("Attempting to start a flight without runing PreFlight()!");
            return;
        }

        state = State.PRE_FLIGHT;
    }

    public void StopFlight()
    {
        if(state != State.FLIGHT) {
            Debug.LogError("Attempting to end a flight without running StartFlight()!");
            return;
        }

        state = State.NONE;
    }

    // Update is called once per frame
    void Update() {
        if(state == State.FLIGHT)
        {
            AvatarInstance avatarInstance = getCurrentAvatarInstance();
            avatarInstance.Update();
        }
    }

    public int getNumSlotsOpen() {
        return curNumSlotsOpen;
    }

    //Inserts (overwrites) all avatar slots with the passed in list, in the same order (call this after sphere slots are updated, for example)
    //Also sets the number of open slots equal to the size of the passed in list (so this will expand to more slots)
    //Also resets the curAvatarIndex to 0 (first in the given list)
    public void updateAvatars(List<Avatar> orderedAvatars) {
        avatarSlot.Clear();
        avatarSlot.AddRange(orderedAvatars);
        curAvatarIndex = 0;
    }

    public Avatar getCurrentAvatar() {
        return avatarSlot[curAvatarIndex];
    }

    //Using a numerical index, start a transition from the current index to the next
    public void transitionToNextAvatar(int nextIndex, float msDelay = 0) {
        curAvatarIndex = nextIndex; //TODO factor in time
        Ability newAbilities = getCurrentAvatarInstance().abilities;
        changePlayerAttributes(newAbilities);
        Debug.Log("Avatar transition complete");
    }

    //Set the given abilites to apply to the active player
    //TODO this is a prototype, we may want to make this more sophisticated by lerping and adding in time considerations etc
    public void changePlayerAttributes(Ability a) {

        GameObject player = GameController.instance.getPlayerObj();

        //this is only a prototype of how this should work....improvements welcome
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        //optionally we could turn these lift or dive forces into a one-time impulse force by using AddForce
        float gForce = (float) (1.0 - (a.liftForce * a.liftForceMult)) + (a.diveForce * a.diveForceMult);
        if(gForce < 0) {
            Debug.Log("Negative gravity detected!");
        }
        rb.gravityScale = gForce;
        rb.mass = a.mass * a.liftForceMult;
        rb.drag = a.drag * a.dragMult;


    }

}
