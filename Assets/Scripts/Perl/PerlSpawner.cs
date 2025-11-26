using System;
using System.Collections;
using UnityEngine;

public class PerlSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _preSpawn;
    [SerializeField] private Perl _prefab;
    [SerializeField] private PerlSpawnArea _spawnArea;
    private GenericPool<Perl> _pool;

    private void Start()
    {
        _pool = new GenericPool<Perl>(_prefab);
        PreSpaw();
        StartCoroutine(SpawnPerls());
    }

    private IEnumerator SpawnPerls()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            yield return delay;
            SpawnPerl();
        }
    }

    private void SpawnPerl()
    {
        Perl perl = _pool.Get();
        perl.transform.position = _spawnArea.GetSpawnPosition();
        perl.Release += Release;
    }

    private void PreSpaw()
    {
        for (int i = 0; i < _preSpawn; i++)
        {
            SpawnPerl();
        }
    }

    private void Release(Perl perl)
    {
        perl.Release -= Release;
        _pool.Release(perl);
    }
}
