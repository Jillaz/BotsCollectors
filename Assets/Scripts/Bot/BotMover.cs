using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _targetPosition = null;    

    private void Update()
    {
        if (_targetPosition != null)
        {
            Move();
        }
    }

    public void SetTarget(Transform target)
    {
        _targetPosition = target.transform;
    }

    public void StopMoving()
    {
        _targetPosition = null;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _speed * Time.deltaTime);
    }
}
