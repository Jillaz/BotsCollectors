using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    public event Action PerlDelivered;

    public void TakeResource(Perl perl)
    {
        perl.Delivered();
        PerlDelivered?.Invoke();
    }
}
