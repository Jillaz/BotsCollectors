using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    public event Action PerlDelivered;

    public void GetResource(Perl perl)
    {
        perl.Delivered();
        PerlDelivered?.Invoke();
    }
}
