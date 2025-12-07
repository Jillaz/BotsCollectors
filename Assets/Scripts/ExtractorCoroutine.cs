using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ExtractorCoroutine : MonoBehaviour
{
    [SerializeField] private Transform _storage;
    [SerializeField] private float _liftSpeed = 1f;
    [SerializeField] private float _targetDistanceOffset = 0.1f;
    private Transform _cylinder;

    public IEnumerator Extract(Transform target)
    {
        _cylinder = target;
        _cylinder.SetParent(transform);

        while (Vector3.Distance(_cylinder.position, _storage.position) > _targetDistanceOffset)
        {
            _cylinder.position = Vector3.MoveTowards(_cylinder.position, _storage.position, _liftSpeed * Time.deltaTime);

            yield return null;
        }

        _cylinder.position = _storage.position;

        Debug.Log("Погузка завершена");

        yield return null;
    }

    public IEnumerator ReleaseFromStorage()
    {        
        while (Vector3.Distance(_cylinder.position, transform.position) > _targetDistanceOffset)
        {
            _cylinder.position = Vector3.MoveTowards(_cylinder.position, transform.position, _liftSpeed * Time.deltaTime);

            yield return null;
        }

        _cylinder.position = transform.position;

        _cylinder.SetParent(transform);
        Debug.Log("Выгрузка завершена");

        yield return null;  
    }
}
