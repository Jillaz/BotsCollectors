using UnityEngine;

public class Bot : MonoBehaviour
{
    public bool IsBusy { get; private set; } = false;

    [SerializeField] private BotMover _botMover;
    [SerializeField] private BotExtractor _extractor;
    private Base _base;
    private Perl _perlToGet;

    public void GetPerl(Perl perl)
    {
        if (perl == null)
        {
            return;
        }

        IsBusy = true;
        _perlToGet = perl;
        perl.Busy();
        _botMover.SetTarget(perl.transform);
    }

    public void SetBasePosition(Base mainBase)
    {
        _base = mainBase;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Perl perl) && (_perlToGet == perl))
        {
            _extractor.PutInStorage(perl);
            BackToBase();
        }
        else if (other.TryGetComponent(out Base mainBase) && _extractor.IsStorageFull)
        {
            mainBase.GetResource(_extractor.GetFromStorage());
            AwaitingOrders();
        }
    }

    private void BackToBase()
    {
        _botMover.SetTarget(_base.transform);
    }

    private void AwaitingOrders()
    {
        IsBusy = false;
        _botMover.StopMoving();
    }
}
