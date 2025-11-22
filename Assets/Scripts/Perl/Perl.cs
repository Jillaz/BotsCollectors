using System;
using UnityEngine;

public class Perl : MonoBehaviour
{
    public event Action<Perl> Release;

    public void Delivered()
    {
        Release?.Invoke(this);
    }
}
