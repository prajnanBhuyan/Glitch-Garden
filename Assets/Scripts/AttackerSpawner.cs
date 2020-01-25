using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    float minSpawnDelay = 1f;
    [SerializeField]
    float maxSpawnDelay = 5f;
    [SerializeField]
    Attacker attackerPrefab;

    bool spawn = true;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }

    private void Spawn()
    {
        var newAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
