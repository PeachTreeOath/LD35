using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour {
    public int value;

    public void Collect()
    {
        Destroy(gameObject); //temporary
    }
}
