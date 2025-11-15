using System.Collections.Generic;
using UnityEngine;

public class PerlLocator : MonoBehaviour
{
    [SerializeField] private float _searchRadius;
    [SerializeField] private LayerMask _layerMask;

    public List<Perl> Search()
    {
        List<Perl> _perl = new List<Perl>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _searchRadius, _layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Perl perl))
            {
                if (perl.IsBusy == false)
                {
                    _perl.Add(perl);
                }
            }
        }

        return _perl;
    }
}
