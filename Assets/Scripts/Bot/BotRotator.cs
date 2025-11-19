using UnityEngine;

public class BotRotator : MonoBehaviour
{
    private Transform _target;    

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void StopRotating()
    {
        _target = null;
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        transform.LookAt(_target.position);
    }
}
