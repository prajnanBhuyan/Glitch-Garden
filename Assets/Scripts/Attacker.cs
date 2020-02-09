using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // TODO: Maybe make this a serialized field and create a new public method StartMoving()
    //       to be called instead of SetMovementSpeed(value_passed_from_animator_controller)
    [Range(0f, 5f)]
    float movementSpeed = 0f;

    GameObject currentTarget;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>()?.AttackerDestroyed();
    }

    void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
