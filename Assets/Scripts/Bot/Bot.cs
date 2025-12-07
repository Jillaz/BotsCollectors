using System.Collections;
using TMPro.EditorUtilities;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private MoverCoroutine _mover;
    [SerializeField] private RotatorCoroutine _rotator;
    [SerializeField] private ExtractorCoroutine _extractor;
    private Perl _perl;
    private Base _base;
    private Transform _unloadPlace;

    public bool IsBusy { get; private set; } = false;

    private IEnumerator ActionsQueue()
    {
        yield return _rotator.SmoothLookAt(_perl.transform.position);
        yield return _mover.MoveTo(_perl.transform.position);
        yield return _extractor.Extract(_perl);
        yield return _rotator.SmoothLookAt(_unloadPlace.position);
        yield return _mover.MoveTo(_unloadPlace.position);
        yield return _extractor.ReleaseFromStorage();

        IsBusy = false;
        _base.TakeResource(_perl);
        yield return null;
    }

    public void SetPerl(Perl perl)
    {
        IsBusy = true;
        _perl = perl;
        StartCoroutine(ActionsQueue());
    }

    public void SetBasePosition(Base mainBase)
    {
        _base = mainBase;
        _unloadPlace = _base.SetUnloadPlace();
    }
}
