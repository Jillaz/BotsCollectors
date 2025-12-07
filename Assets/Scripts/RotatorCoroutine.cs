using System.Collections;
using UnityEngine;

public class RotatorCoroutine : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _targetRotationOffset = 1f;

    public IEnumerator SmoothLookAt(Vector3 targetPosition)
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
}
