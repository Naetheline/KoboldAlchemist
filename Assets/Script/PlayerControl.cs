using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public const int LIMIT = 26;
    public const float ACCELERATION_MOD = 0.5f;
    public const float ACCELERATION_THRESHOLD = 0.1f;
    void Update()
    {
        float acceleration = Input.acceleration.x; 

        if(Mathf.Abs(acceleration) < ACCELERATION_THRESHOLD)
        {
            acceleration = 0;
        }

        transform.Translate(acceleration * ACCELERATION_MOD, 0, 0);
        Vector3 clampedPosition = new Vector3( Mathf.Clamp(transform.position.x, -LIMIT, LIMIT), transform.position.y, transform.position.z);
        transform.position = clampedPosition;
    }
}
