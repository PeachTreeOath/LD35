using UnityEngine;
using System.Collections;

public class Tastiness : MonoBehaviour {

    public GameObject magnetObject;

    private float range;
    private bool isPrey = false;

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
            BecomeTheHunter(range);
    }

    void BecomeTheHunted(float range) {
        Magnet magnet = magnetObject.GetComponent<Magnet>();

        magnet.Range = range;
    }

    void BecomeTheHunter(float range) {
        Magnet magnet = magnetObject.GetComponent<Magnet>();

        magnet.Range = 0;
        magnet.Demagnetize();
    }

    bool OnObstacleEnter(Collider2D collider)
    {
        return true;
    }
}
