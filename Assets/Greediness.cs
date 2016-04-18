using UnityEngine;
using System.Collections;

public class Greediness : MonoBehaviour {

    public GameObject magnetObject;

	public float Value
    {
        get
        {
            Magnet magnet = magnetObject.GetComponent<Magnet>();
            return magnet.Range;
        }
        set
        {
            Magnet magnet = magnetObject.GetComponent<Magnet>();
            magnet.Range = value;
        }
    }
}
