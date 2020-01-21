using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // TODO: Maybe make this a serialized field and create a new public method StartMoving()
    //       to be called instead of SetMovementSpeed(value_passed_from_animator_controller)
    [Range(0f, 5f)]
    float movementSpeed = 0f;

    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed  * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
}
