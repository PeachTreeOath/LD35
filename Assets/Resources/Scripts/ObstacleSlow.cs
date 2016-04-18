using UnityEngine;
using System.Collections;

public class ObstacleSlow : LevelObject {

    public float reduction = 0;
    public float speedLimit = float.MaxValue;

    public override void Remove() {
        Destroy(gameObject);
    }

    public void DoDefaultSlow(Rigidbody2D body)
    {
        float xSpeed = body.velocity.x;

        xSpeed = Mathf.Clamp(xSpeed, 0, speedLimit);
        xSpeed = xSpeed - (xSpeed * Mathf.Clamp(reduction, 0, 1));

        float ySpeed = body.velocity.y;

        ySpeed = Mathf.Clamp(ySpeed, -speedLimit, speedLimit);
        ySpeed = ySpeed * (1 - Mathf.Clamp(reduction, 0, 1));

        body.velocity = new Vector2(xSpeed, ySpeed);

        Remove();
    }
}
