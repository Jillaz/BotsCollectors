using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField] private PerlsLocator _perlsLocator;
    [SerializeField] private CapturedPerls _capturedPerls;
    private List<Perl> _findedPerls = new List<Perl>();

    public Perl Get()
    {
        Perl perl = null;
        Add();

        if (_findedPerls.Count != 0)
        {
            foreach (var item in _findedPerls)
            {
                if (_capturedPerls.Contains(item) == false)
                {
                    _capturedPerls.Add(item);
                    perl = item;
                    perl.Release += ClearDeliveredPerl;
                    break;
                }
            }

            return perl;
        }
        else
        {
            return null;
        }
    }

    private void Add()
    {
        _findedPerls = _perlsLocator.Search();
    }

    private void ClearDeliveredPerl(Perl perl)
    {
        perl.Release -= ClearDeliveredPerl;
        _capturedPerls.Remove(perl);
    }
}

