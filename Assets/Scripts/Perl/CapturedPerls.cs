using System.Collections.Generic;
using UnityEngine;

public class CapturedPerls : MonoBehaviour
{
    private HashSet<Perl> _capturedPerls = new HashSet<Perl>();

    public void Add(Perl perl)
    {
        _capturedPerls.Add(perl);
    }

    public void Remove(Perl perl)
    {
        _capturedPerls.Remove(perl);
    }

    public bool Contains(Perl perl)
    {
        return _capturedPerls.Contains(perl);
    }
}
