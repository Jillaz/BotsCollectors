using System.Collections;
using UnityEngine;

public class MoverCoroutine : MonoBehaviour
{    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _targetDistanceOffset = 1f;  

    public IEnumerator MoveTo(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > _targetDistanceOffset)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);

            yield return null;
        }

        transform.position = targetPosition;
        Debug.Log($"Достиг цели {targetPosition}");
    }
}
