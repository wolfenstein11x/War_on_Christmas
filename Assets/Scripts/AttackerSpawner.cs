using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackers;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // bug fix to prevent crashing if shooter placed in inactive lane
        if (attackers.Length <= 0) { spawn = false; }

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackers.Length);

        Spawn(attackers[attackerIndex]);   
    }

    private void Spawn(Attacker myAttacker)
    {
        // bug fix to prevent delayed spawn after level timer ended
        if (!spawn) { return; }

        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;

        // make it so the instances go into a parent gameobject and don't clutter the hierarchy
        newAttacker.transform.parent = transform;
    }

    
}
