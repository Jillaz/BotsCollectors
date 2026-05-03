using System.Collections;
using UnityEngine;

public class MoverCoroutine : MonoBehaviour
{    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _targetDistanceOffset = 1f;

    public IEnumerator MoveTo(Vector3 targetPosition)
    {        
        while (IsTargetReached(targetPosition) == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPosition;
    }

    private bool IsTargetReached(Vector3 targetPosition)
    {
        return transform.position.IsEnoughClose(targetPosition, _targetDistanceOffset);
    }
}
