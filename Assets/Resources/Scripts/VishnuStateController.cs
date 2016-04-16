using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Use this for checking/transitioning vishnu's avatar
public class VishnuStateController : MonoBehaviour {

    //Singleton accessor for this obj. I think this will work...
    public static VishnuStateController instance { get { return m_instance; } }

    public enum Avatar { MATSYA, KURMA, VARAHA, NARASIMHA, VAMANA, PARASHURAMA, RAMA, KRISHNA, BUDDHA, KALKI };


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
        }
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

    //Inserts (overwrites) all avatar slots with the passed in list, in the same order
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
        curAvatarIndex = nextIndex; //TODO
    }



}
