using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    LivesDisplay livesDisplay;

    private void OnTriggerEnter2D()
    {
        livesDisplay.ReduceLife();
    }

    void Start()
    {
        livesDisplay = FindObjectOfType<LivesDisplay>();
    }
}
