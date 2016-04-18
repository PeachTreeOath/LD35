using UnityEngine;
using System.Collections;

public class Tastiness : MonoBehaviour {

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

    }

    void BecomeTheHunter(float range) {

    }

    bool OnObstacleEnter(Collider2D collider)
    {
        return true;
    }
}
