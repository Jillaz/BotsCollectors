using System.Collections;
using UnityEngine;

public class ExtractorCoroutine : MonoBehaviour
{
    [SerializeField] private Transform _storage;
    [SerializeField] private float _liftSpeed = 1f;
    [SerializeField] private float _targetDistanceOffset = 0.1f;
    private Perl _perl;

    public IEnumerator Extract(Perl target)
    {
        _perl = target;
        _perl.transform.SetParent(transform);

        while (Vector3.Distance(_perl.transform.position, _storage.position) > _targetDistanceOffset)
        {
            _perl.transform.position = Vector3.MoveTowards(_perl.transform.position, _storage.position, _liftSpeed * Time.deltaTime);

            yield return null;
        }

        _perl.transform.position = _storage.position;

        yield return null;
    }

    public IEnumerator ReleaseFromStorage()
    {        
        while (Vector3.Distance(_perl.transform.position, transform.position) > _targetDistanceOffset)
        {
            _perl.transform.position = Vector3.MoveTowards(_perl.transform.position, transform.position, _liftSpeed * Time.deltaTime);

            yield return null;
        }

        _perl.transform.position = transform.position;

        _perl.transform.SetParent(null);

        yield return null;
    }
}
