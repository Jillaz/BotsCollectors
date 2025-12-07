using System.Collections;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private MoverCoroutine _mover;
    [SerializeField] private RotatorCoroutine _rotator;
    [SerializeField] private ExtractorCoroutine _extractor;
    private Perl _perl;
    private Base _base;

    public bool IsBusy { get; private set; } = false;

    private IEnumerator ActionsQueue()
    {
        yield return _rotator.SmoothLookAt(_perl.transform.position);
        yield return _mover.MoveTo(_perl.transform.position);
        yield return _extractor.Extract(_perl);
        yield return _rotator.SmoothLookAt(_base.transform.position);
        yield return _mover.MoveTo(_base.transform.position);
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
    }
}
