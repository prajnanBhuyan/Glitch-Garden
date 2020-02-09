using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject winLabel;
    [SerializeField]
    GameObject loseLabel;
    [SerializeField]
    float waitToLoad = 4f;

    int numberOfAttackers;
    bool levelTimerFinished;
    bool roundOver;

    private void Start()
    {
        winLabel?.SetActive(false);
        loseLabel?.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        if (!roundOver)
        {
            roundOver = true;
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitToLoad);
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
    }

    public void HandleLoseCondition()
    {
        if (!roundOver)
        {
            roundOver = true;
            loseLabel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArrays = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawnerArrays)
        {
            spawner.StopSpawning();
        }
    }
}
