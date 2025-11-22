using UnityEngine;

public class BotExtractor : MonoBehaviour
{
    [SerializeField] Transform _storagePosition;
    private Perl _perl = null;    

    public bool IsStorageFull { get; private set; } = false;

    public void PutInStorage(Perl perl)
    {
        perl.transform.SetParent(transform);
        perl.transform.position = _storagePosition.position;
        IsStorageFull = true;
        _perl = perl;
    }

    public Perl GetFromStorage()
    {
        _perl.transform.SetParent(null);
        IsStorageFull = false;
        return _perl;
    }
}
