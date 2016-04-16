using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Use this for checking/transitioning vishnu's avatar
public class VishnuStateController : MonoBehaviour {

    //Singleton accessor for this obj. I think this will work...
    public static VishnuStateController instance { get { return m_instance; } }

    [SerializeField]
    public enum Avatar { MATSYA, KURMA, VARAHA, NARASIMHA, VAMANA, PARASHURAMA, RAMA, KRISHNA, BUDDHA, KALKI };

    [SerializeField]
    private AbilityData abilityDataRef; //source to load abilites from
    private Dictionary<Avatar, Ability> abilities = new Dictionary<Avatar, Ability>();


    private static VishnuStateController m_instance;
    private int curAvatarIndex;
    private int nextAvatarIndex; //target of transition

    //slots -- used for positioning spheres
    [SerializeField]
    private int maxSlots = 5; //game level constant

    private int curNumSlotsOpen = 2;
    private List<Avatar> avatarSlot = new List<Avatar>(); //0-based index for each slot.
    

    void Awake() {
        if (m_instance == null) {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAbilityData();
            DEBUG_ADD_AVATAR(); //TODO REMOVER
        }else if(m_instance != null && m_instance != this) {
            Debug.Log("Deleting singleton Dup.  Someone screwed up");
            Destroy(gameObject);
            return;
        }
    }

    //FIXME delete references to this before release!
    private void DEBUG_ADD_AVATAR() {
        Debug.Log("Performing debug add avatars!");
        List<Avatar> newSpheres = new List<Avatar>();
        newSpheres.Add(Avatar.BUDDHA);
        newSpheres.Add(Avatar.KALKI);
        newSpheres.Add(Avatar.PARASHURAMA);
        updateAvatars(newSpheres);
    }

    private void LoadAbilityData() {
        if(abilityDataRef == null) {
            Debug.LogError("No ability data specified!");
            return;
        }

        foreach(AvatarAbilityEntry ent in abilityDataRef.getAll()){
            abilities[ent.avatar] = ent.abilities; 
        }
        Debug.Log("Abilities loaded!");
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

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
        Ability newAbilities = abilities[getCurrentAvatar()];
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
