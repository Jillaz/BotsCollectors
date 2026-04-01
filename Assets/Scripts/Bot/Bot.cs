using System.Collections;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private MoverCoroutine _mover;
    [SerializeField] private RotatorCoroutine _rotator;
    [SerializeField] private ExtractorCoroutine _extractor;
    private Perl _perl;
    private Base _base;
    private Transform _unloadingLocation;

    public bool IsBusy { get; private set; } = false;

    private IEnumerator ActionsQueue()
    {
        yield return _rotator.SmoothLookAt(_perl.transform.position);
        yield return _mover.MoveTo(_perl.transform.position);
        yield return _extractor.Extract(_perl);
        yield return _rotator.SmoothLookAt(_unloadingLocation.position);
        yield return _mover.MoveTo(_unloadingLocation.position);
        yield return _extractor.ReleaseFromStorage();

        IsBusy = false;
        _base.TakeResource(_perl);
        yield return null;
    }

    private IEnumerator BuildingActionsQueue(Vector3 buildPlace, Base basePrefab)
    {
        Debug.Log("Bot: " + buildPlace);
        yield return _rotator.SmoothLookAt(buildPlace);
        yield return _mover.MoveTo(buildPlace);
        Instantiate(basePrefab, buildPlace, Quaternion.identity);

        IsBusy = false;
        yield return null;
    }

    public void SetPerl(Perl perl)
    {
        if (perl == null)
        {
            return;
        }

        IsBusy = true;
        _perl = perl;
        StartCoroutine(ActionsQueue());
    }

    public void StartBuilding(Vector3 buildPlace, Base basePrefab)
    {
        IsBusy = true;
        _base = null;
        _unloadingLocation = null;
        StartCoroutine(BuildingActionsQueue(buildPlace, basePrefab));
    }

    public void SetBasePosition(Base mainBase)
    {
        if (_base == null)
        {
            _base = mainBase;
            _unloadingLocation = _base.UnloadingLocation();
        }
    }
}
