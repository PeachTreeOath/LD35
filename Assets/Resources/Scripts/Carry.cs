using UnityEngine;
using System.Collections;

public class Carry : MonoBehaviour {

    private bool isCarrying = false;
    private float carryTimer = 0f;

    public Vector2 velocity;

    public GameObject load;
    public float timeToCarry = 2.5f;
    public float carrySpeed = 20f;

    public void StartCarry(GameObject gameObject) {
        load = gameObject;

        Rigidbody2D carrierBody = gameObject.GetComponent<Rigidbody2D>();
        
        
        carryTimer = timeToCarry;
        isCarrying = true;
    }

    public void StopCarry() {
        isCarrying = false;

        Rigidbody2D carrierBody = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D loadBody = load.GetComponent<Rigidbody2D>();

        loadBody.velocity = new Vector2(carrySpeed, 0f);

        Destroy(gameObject);
    }

    void LateUpdate() {
        Rigidbody2D carrierBody = gameObject.GetComponent<Rigidbody2D>();

        if (isCarrying) {
            carryTimer -= Time.deltaTime;
            if (carryTimer <= 0f)
                StopCarry();
            else
            {
                carrierBody.velocity = new Vector2(carrySpeed, 0f);

                Rigidbody2D loadBody = load.GetComponent<Rigidbody2D>();

                loadBody.position = carrierBody.position;
                loadBody.velocity = Vector2.zero;
            }
        }
    }
}