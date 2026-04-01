using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Transform _unloadingLocation;

    public event Action PerlDelivered;

    public void TakeResource(Perl perl)
    {
        perl.Delivered();
        PerlDelivered?.Invoke();
    }

    public Transform UnloadingLocation()
    {
        return _unloadingLocation;
    }
}
