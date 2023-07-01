using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private float spawnMinTime = 1f;
    [SerializeField] private float spawnMaxTime = 5f;
    [SerializeField] private Attacker[] attackerPrefabArray;


    private bool spawn = true;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(spawnMinTime, spawnMaxTime));
            selectAttacker();
        }
    }

    public void stopSpawning()
    {
        spawn = false;
    }


    private void selectAttacker()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attackerPrefabArray.Length);
        spawnAttacker(attackerPrefabArray[attackerIndex]);
    }

    private void spawnAttacker(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
