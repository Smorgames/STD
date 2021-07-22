using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private List<Wave> _waves; 

    public IEnumerator SpawnWave(/*Need data about current wave*/)
    {
        while (true) // until all enemies pass
        {

        }

        yield return null;
    }

    private void SpawnEnemy()
    {

    }    
}