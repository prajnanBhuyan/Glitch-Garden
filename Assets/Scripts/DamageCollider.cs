using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    LivesDisplay livesDisplay;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        livesDisplay.ReduceLife();
        Destroy(otherCollider.gameObject);
    }

    void Start()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }
}
