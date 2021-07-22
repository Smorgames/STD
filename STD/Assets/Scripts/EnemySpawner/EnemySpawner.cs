using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRateBetweenWaves;
    [SerializeField] private List<Wave> _waves;

    private float _spawnRateCounter;
    private bool _needSpawnWave;

    private int _currentSpawnWaveNumber;

    private void Awake()
    {
        ResetFieldsToStartValue();
        IncreaseCurrentSpawnWaveNumber();
    }

    private void Update()
    {
        if (_needSpawnWave)
        {
            CountDownDelayBeforeSpawnWave();

            if (DelayPassed())
            {
                ResetFieldsToStartValue();
                StartSpawnWave();
            }
        }
    }

    private void CountDownDelayBeforeSpawnWave()
    {
        _spawnRateCounter += Time.deltaTime;
    }

    private bool DelayPassed()
    {
        return _spawnRateCounter >= _spawnRateBetweenWaves;
    }

    private void StartSpawnWave()
    {
        StartCoroutine(SpawnWaveCoroutine());
    }

    private IEnumerator SpawnWaveCoroutine()
    {
        Wave currentWave = GetWaveByNumber();

        List<Subwave> subwaves = currentWave.Subwaves;
        List<float> delayBeforeSpawnSubwave = currentWave.DelayBeforeSpawnSubwave;

        int subwaveCounter = 0;
        int spawnSubwaveNumber = 1;

        while (subwaveCounter < subwaves.Count)
        {
            SpawnSubwave(subwaves[subwaveCounter]);
            spawnSubwaveNumber++;
            yield return new WaitForSeconds(delayBeforeSpawnSubwave[spawnSubwaveNumber]);
        }

        yield return null;
    }

    private Wave GetWaveByNumber()
    {
        foreach (Wave wave in _waves)
            if (wave.NumberInSequence == _currentSpawnWaveNumber)
                return wave;

        Debug.LogError($"There is no wave with {_currentSpawnWaveNumber} number");
        return null;
    }

    private void SpawnSubwave(Subwave subwave)
    {

    }

    private void SpawnEnemy()
    {

    }

    private void ResetFieldsToStartValue()
    {
        _spawnRateCounter = 0f;
        _needSpawnWave = false;
    }

    private void IncreaseCurrentSpawnWaveNumber()
    {
        _currentSpawnWaveNumber++;
    }
}