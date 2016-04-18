using UnityEngine;
using System.Collections;

public class Tastiness : MonoBehaviour {
    public GameObject magnetObject;

    private float range;
    private bool isPrey = false;
    private bool isCarried = false;
    private GameObject carrier = null;

    public float Value
    {
        get { return range; }
        set
        {
            bool prevPrey = isPrey;

            isPrey = value > 0;
            range = value;

            if (prevPrey != isPrey)
                OnStateChange(isPrey, range);
        }
    }

    void OnStateChange(bool isPrey, float range)
    {
        if (isPrey)
            BecomeTheHunted(range);
        else
        {
            if(isCarried)
                StopCarry();

            BecomeTheHunter(range);
        }
    }

    void BecomeTheHunted(float range) {
        Magnet magnet = magnetObject.GetComponent<Magnet>();

        magnet.Range = range;
    }

    void BecomeTheHunter(float range) {
        TurnOffMagnet();
        StopCarry();
    }

    void StartCarry(GameObject obj) {
        Carry carry = obj.GetComponent<Carry>();
        if (carry != null)
        {
            TurnOffMagnet();

            carrier = obj;
            isCarried = true;

            carry.StartCarry(gameObject);
        }
    }

    void StopCarry() {
        isCarried = false;

        if (carrier != null)
        {
            Carry carry = carrier.GetComponent<Carry>();
            if (carry != null)
                carry.StopCarry();
        }
    }

    void TurnOffMagnet()
    {
        Magnet magnet = magnetObject.GetComponent<Magnet>();

        magnet.Range = 0;
        magnet.Demagnetize();
    }

    bool OnObstacleEnter(Collider2D collider)
    {
        if(isPrey)
        {
            if (isCarried) return false;
            
            if (collider.gameObject.layer == LayerMask.NameToLayer("Birds")) {
                StartCarry(collider.gameObject);
                return false;
            }
            return true;
        }   
        else 
            return true;
    }
}
