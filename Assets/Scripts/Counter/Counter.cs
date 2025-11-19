using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Base _base;
    private int value = 0;

    public event Action<int> ValueChanged;

    private void OnEnable()
    {
        _base.PerlDelivered += ChangeValue;
    }

    private void OnDisable()
    {
        _base.PerlDelivered -= ChangeValue;        
    }

    private void ChangeValue()
    {
        value++;
        ValueChanged?.Invoke(value);
    }
}
