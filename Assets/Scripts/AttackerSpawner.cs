using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
   
    [Header("---Attacker Spawn Time---")]
    [Range(0f, 10f)]
    [SerializeField] float minSpawnDelay = 1f;
    [Range(0f, 10f)]
    [SerializeField] float maxSpawnDeplay = 10f;
    [SerializeField] Attacker[] attackerPrefabArray;
    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDeplay));
            SpawnAttacker();
        }
    }

    public void StopSpawning() //calling in LevelController.
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length); 
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
                (myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform; // Instaniate as a child(clone) for each spawn line. // Spawn a new attacker as a child.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
