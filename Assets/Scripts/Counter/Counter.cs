using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private Base _base;
    private int _value = 0;

    public event Action<int> ValueChanged;

    private void OnEnable()
    {
        _base.PerlDelivered += IncreaseValue;
    }

    private void OnDisable()
    {
        _base.PerlDelivered -= IncreaseValue;        
    }

    private void Start()
    {
        ValueChanged?.Invoke(_value);        
    }

    private void IncreaseValue()
    {
        _value++;
        ValueChanged?.Invoke(_value);
    }

    public void ReduceValue(int value)
    {
        _value -= value;
        ValueChanged?.Invoke(_value);
    }
}
