using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private BotsTaskManager _taskManager;

    public void GetResource(Perl perl)
    {
        perl.Delivered();
        _taskManager.UpdateStatus();
    }
}
