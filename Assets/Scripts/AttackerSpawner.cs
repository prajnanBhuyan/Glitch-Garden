using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    float minSpawnDelay = 1f;
    [SerializeField]
    float maxSpawnDelay = 5f;
    [SerializeField]
    Attacker[] attackerPrefabArray;

    bool spawn = true;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    public void SpawnAttacker()
    {
        var index = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[index]);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        var newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}
