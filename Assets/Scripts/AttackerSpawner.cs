using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Attacker Spawner Configuration")]
    [SerializeField] Attacker[] attackerPrefabArray;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        maxSpawnDelay -= PlayerPrefsController.GetDifficulty();
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

    private void SpawnAttacker()
    {
        Attacker attackerPrefab = attackerPrefabArray[Random.Range(0, attackerPrefabArray.Length)];
        Spawn(attackerPrefab);
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker newAttacker = Instantiate(
                    attackerPrefab, transform.position, transform.rotation
                    ) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
