using System.Collections;
using UnityEngine;

public class RoutineSequencer : MonoBehaviour
{
    //[SerializeField] private Transform _target;
    //[SerializeField] private MoverCoroutine _mover;
    //[SerializeField] private RotatorCoroutine _rotator;
    //[SerializeField] private ExtractorCoroutine _extractor;
    //private Vector3 _startPosition;

    //private void Start()
    //{
    //    _startPosition = transform.position;
    //    StartCoroutine(ActionsQueue());
    //}

    //private IEnumerator ActionsQueue()
    //{
    //    yield return _rotator.SmoothLookAt(_target.position);
    //    yield return _mover.MoveTo(_target.position);
    //    yield return _extractor.Extract(_target);
    //    yield return _rotator.SmoothLookAt(_startPosition);
    //    yield return _mover.MoveTo(_startPosition);
    //    yield return _extractor.ReleaseFromStorage();

    //    Debug.Log("Работа закончена");
    //    yield return null;
    //}

    //public void SetTarget(Transform target)
    //{
    //    _target = target;
    //    StartCoroutine(ActionsQueue());
    //}
}
