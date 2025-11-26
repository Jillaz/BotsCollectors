using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField] private PerlsLocator _perlsLocator;
    private List<Perl> _freePerls = new List<Perl>();
    private List<Perl> _getedPerls = new List<Perl>();

    public Perl Get()
    {
        int firstInList = 0;
        Perl perl = null;
        Add();

        if (_freePerls.Count != 0)
        {
            perl = _freePerls[firstInList];
            _getedPerls.Add(perl);
            perl.Release += ClearDeliveredPerl;
            return perl;
        }
        else
        {
            return null;
        }
    }

    private void Add()
    {
        _freePerls = _perlsLocator.Search();

        foreach (var item in _getedPerls)
        {
            if (_freePerls.Contains(item))
            {
                _freePerls.Remove(item);
            }
        }
    }

    private void ClearDeliveredPerl(Perl perl)
    {
        perl.Release -= ClearDeliveredPerl;
        _getedPerls.Remove(perl);
    }
}

