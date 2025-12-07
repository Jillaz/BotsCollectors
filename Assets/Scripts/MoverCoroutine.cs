using System.Collections;
using TMPro;
using UnityEngine;

public class MoverCoroutine : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _targetDistanceOffset = 1f;
    [SerializeField] private float _targetRotationOffset = 1f;
    [SerializeField] private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        StartCoroutine(MoveToQueue());
    }

    private IEnumerator MoveTo(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > _targetDistanceOffset)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPosition;
        Debug.Log($"Достиг цели {targetPosition}");
    }

    private IEnumerator SmoothLookAt(Vector3 targetPosition)
    {
        Vector3 lookDirection = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

        while (Quaternion.Angle(transform.rotation, targetRotation) > _targetRotationOffset)
        {
            float step = _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            yield return null;
        }

        transform.rotation = targetRotation;
        Debug.Log($"Повернулся к цели {targetPosition}");
    }

    private IEnumerator MoveToQueue()
    {
        yield return SmoothLookAt(_targetPosition.position);
        yield return MoveTo(_targetPosition.position);
        yield return SmoothLookAt(_startPosition);
        yield return MoveTo(_startPosition);

        Debug.Log("Работа закончена");
        yield return null;
    }
}
