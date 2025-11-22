using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField] private PerlSpawner _spawner;
    [SerializeField] private List<Perl> _freePerls = new List<Perl>();

    private void OnEnable()
    {
        _spawner.Spawned += Add;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= Add;
    }

    private void Add(Perl perl)
    {
        if (_freePerls.Contains(perl) == false)
        {
            _freePerls.Add(perl);
        }
    }

    public Perl Get()
    {
        int firstInList = 0;
        Perl perl = null;

        if (_freePerls.Count != 0)
        {
            perl = _freePerls[firstInList];
            _freePerls.Remove(perl);
            return perl;
        }
        else
        {
            return null;
        }
    }
}

