using System;
using UnityEngine;

public class Perl : MonoBehaviour
{
    public bool IsBusy { get; private set; } = false;

    public event Action<Perl> Release;

    public void Busy()
    {
        IsBusy = true;
    }

    public void Delivered()
    {
        Release?.Invoke(this);
    }

    public void Free()
    {
        IsBusy = false;
    }
}
