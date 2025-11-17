using UnityEngine;

public class BotRotator : MonoBehaviour
{
    private Transform _target;

    private void Update()
    {
        if(_target == null)
        {
            return;
        }

        transform.LookAt(_target.position);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void StopRotating()
    {
        _target = null;
    }
}
