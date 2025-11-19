using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private BotsTaskManager _taskManager;

    public event Action PerlDelivered;

    public void GetResource(Perl perl)
    {
        perl.Delivered();
        PerlDelivered?.Invoke();
    }
}
